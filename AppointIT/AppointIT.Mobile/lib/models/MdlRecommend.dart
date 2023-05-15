class MdlRecommend {
  final int id;
  final int serviceId;
  final int customerId;
  final String serviceName;
  final double servicePrice;
  MdlRecommend({
    required this.id,
    required this.serviceId,
    required this.customerId,
    required this.serviceName,
    required this.servicePrice,
  });
  factory MdlRecommend.fromJson(Map<String, dynamic> json) {
    return MdlRecommend(
      id: json["id"],
      serviceId: json["serviceId"],
      customerId: json["customerId"],
      serviceName: json["serviceName"],
      servicePrice: json["servicePrice"],
    );
  }
}