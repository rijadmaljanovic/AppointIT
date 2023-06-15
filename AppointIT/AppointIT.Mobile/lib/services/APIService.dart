import 'dart:convert';
import 'dart:io';
import 'package:appointit/models/MdlSalonRating.dart';
import 'package:http/http.dart' as http;

class APIService {
  static String username = "";
  static String password = "";
  static String confirmPassword = "";
  static String lastName = "";
  static String firstName = "";

  String route = '';

  APIService(String route) {
    this.route = route;
  }

  // ignore: non_constant_identifier_names
  void SetParameter(String UserName, String Password) {
    username = UserName;
    password = Password;
  }

  static Future<dynamic> Register(String route, dynamic obj) async {
    String baseUrl = "http://10.0.2.2:5001/" + route;
    final response = await http.post(
      Uri.parse(baseUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(obj),
    );
    print(response.statusCode);
  }

  // ignore: non_constant_identifier_names
  static Future<dynamic> Post(String route, dynamic obj) async {
    String baseUrl = "http://10.0.2.2:5001/" + route;
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.post(
      Uri.parse(baseUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization': basicAuth,
      },
      body: jsonEncode(obj),
    );
    print(baseUrl);
    print(response.statusCode);
    print(jsonEncode(obj));
  }

  // ignore: non_constant_identifier_names
  static Future<dynamic> Put(String route, int id, dynamic obj) async {
    String baseUrl = "http://10.0.2.2:5001/" + route + "/" + id.toString();
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.put(Uri.parse(baseUrl),
        headers: <String, String>{
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': basicAuth,
        },
        body: jsonEncode(obj));
  }

  // ignore: non_constant_identifier_names
  static Future<List<dynamic>?> Get(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;
    String baseUrl = "http://10.0.2.2:5001/" + route;
    print(baseUrl);
    if (object != null) {
      baseUrl = baseUrl + '?' + queryString;
    }
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {'Authorization': basicAuth},
    );
    if (response.statusCode == 200) {
      return json.decode(response.body) as List;
    }
    return null;
  }

  // ignore: non_constant_identifier_names
  static Future<List<MdlSalonRating>?> GetRatings(
      String route, dynamic object) async {
    final Map<String, dynamic> queryParams = {
      'customerId': object['customerId'],
      'salonId': object['salonId'],
    };
    final String queryString = queryParams.entries
        .map((entry) => '${entry.key}=${entry.value}')
        .join('&');

    String baseUrl = "http://10.0.2.2:5001/" + route;
    print(baseUrl);
    if (queryString.isNotEmpty) {
      baseUrl = '$baseUrl?$queryString';
    }

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {'Authorization': basicAuth},
    );
    if (response.statusCode == 200) {
      final List<dynamic> jsonResponse = json.decode(response.body);
      return jsonResponse.map((item) => MdlSalonRating.fromJson(item)).toList();
    } else {
      throw Exception('Failed to load ratings');
    }
  }

  // ignore: non_constant_identifier_names
  static Future<int?> GetLast(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;
    String baseUrl = "http://10.0.2.2:5001/" + route;
    print(baseUrl);
    if (object != null) {
      baseUrl = baseUrl + '?' + queryString;
    }
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {'Authorization': basicAuth},
    );
    if (response.statusCode == 200) {
      return json.decode(response.body) as int;
    }
    return null;
  }

  // ignore: non_constant_identifier_names
  static Future<List<dynamic>?> GetListById(String route, int id) async {
    String baseUrl = "http://10.0.2.2:5001/" + route + "/" + id.toString();
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {'Authorization': basicAuth},
    );
    if (response.statusCode == 200) return json.decode(response.body);
    return null;
  }

  // ignore: non_constant_identifier_names
  static Future<dynamic> GetById(String route, int id) async {
    String baseUrl = "http://10.0.2.2:5001/" + route + "/" + id.toString();
    print(baseUrl);
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {'Authorization': basicAuth},
    );
    if (response.statusCode == 200) return json.decode(response.body);
    return null;
  }
}
