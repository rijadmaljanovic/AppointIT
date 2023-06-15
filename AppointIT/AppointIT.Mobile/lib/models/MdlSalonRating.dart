import 'dart:convert';

class MdlSalonRating {
  final int? salonRatingId;
  final double? rating;
  final int? customerId;
  final int? salonId;

  MdlSalonRating(
      {this.rating, this.customerId, this.salonId, this.salonRatingId});

  factory MdlSalonRating.fromJson(Map<String, dynamic> json) {
    return MdlSalonRating(
      salonRatingId: json['salonRatingId'],
      rating: (json['rating'] as num?)?.toDouble(),
      customerId: json['customerId'],
      salonId: json['salonId'],
    );
  }

  Map<String, dynamic> toJson() => {
        "salonRatingId": salonRatingId,
        "rating": rating,
        "customerId": customerId,
        "salonId": salonId,
      };
}
