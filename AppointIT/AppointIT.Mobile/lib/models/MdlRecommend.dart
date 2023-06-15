class MdlRecommend {
  final int id;
  final String name;
  final String location;
  final String description;
  final double lat;
  final double lng;
  MdlRecommend({
    required this.id,
    required this.name,
    required this.location,
    required this.description,
    required this.lat,
    required this.lng,
  });
  factory MdlRecommend.fromJson(Map<String, dynamic> json) {
    return MdlRecommend(
      id: json["id"],
      name: json["name"],
      location: json["location"],
      description: json["description"],
      lat: json["lat"],
      lng: json["lng"],
    );
  }
}
