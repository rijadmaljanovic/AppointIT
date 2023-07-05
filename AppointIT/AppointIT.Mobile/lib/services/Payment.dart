import 'dart:convert';

import 'package:flutter/services.dart';
import 'package:http/http.dart' as http;
import 'package:stripe_payment/stripe_payment.dart';
import 'package:appointit/.env';

class StripeTransactionResponse {
  String message;
  bool success;
  StripeTransactionResponse({required this.message, required this.success});
}

class StripeService {
  static String apiBase = 'https://api.stripe.com/v1';
  static String paymentApiUrl = '${StripeService.apiBase}/charges';
  static Uri paymentApiUri = Uri.parse(paymentApiUrl);

  static String secret = const String.fromEnvironment("stripeSecretKey",
      defaultValue: stripeSecretKey);

  static String publishableKey = const String.fromEnvironment(
      "stripePublishableKey",
      defaultValue: stripePublishableKey);

  static Map<String, String> headers = {
    'Authorization': 'Bearer ${StripeService.secret}',
    'Content-type': 'application/x-www-form-urlencoded'
  };

  static init() {
    StripePayment.setOptions(StripeOptions(
        publishableKey: publishableKey,
        merchantId: 'test',
        androidPayMode: 'test'));
  }

  static Future<Map<String, dynamic>?> createPaymentIntent(
      String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        "amount": amount,
        "currency": currency,
        "description": 'Placanje termina',
        "source": "tok_mastercard"
      };
      var response =
          await http.post(paymentApiUri, headers: headers, body: body);
      return jsonDecode(response.body);
    } catch (error) {
      print('error occured in the payment intent $error');
    }
    return null;
  }

  static Future<StripeTransactionResponse> payWithNewCard(
      {required String amount, required String currency}) async {
    try {
      var paymentMethod = await StripePayment.paymentRequestWithCardForm(
          CardFormPaymentRequest());
      var paymentIntent =
          await StripeService.createPaymentIntent(amount, currency);
      var response = await StripePayment.confirmPaymentIntent(PaymentIntent(
          clientSecret: paymentIntent!['client_secret'],
          paymentMethodId: paymentMethod.id));
      print(response.toJson());
      if (response.status == 'succeeded') {
        return StripeTransactionResponse(
            message: 'Transaction successful', success: true);
      } else {
        return StripeTransactionResponse(
            message: 'Transaction failed', success: false);
      }
    } on PlatformException catch (error) {
      return StripeService.getPlatformExceptionErrorResult(error);
    } catch (error) {
      return StripeTransactionResponse(
          message: 'Transaction failed : $error', success: false);
    }
  }

  static getPlatformExceptionErrorResult(err) {
    String message = 'Something went wrong';
    if (err.code == 'cancelled') {
      message = 'Transaction cancelled';
    }
    return new StripeTransactionResponse(message: message, success: false);
  }
}
