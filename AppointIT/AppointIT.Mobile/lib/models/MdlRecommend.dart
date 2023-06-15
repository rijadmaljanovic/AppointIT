class MdlRecommend {
  final int id;
  final int categoryId;
  final double duration;
  final String name;
  final double price;
  MdlRecommend({
    required this.id,
    required this.categoryId,
    required this.duration,
    required this.name,
    required this.price,
  });
  factory MdlRecommend.fromJson(Map<String, dynamic> json) {
    return MdlRecommend(
      id: json["id"],
      categoryId: json["categoryId"],
      duration: json["duration"],
      name: json["name"],
      price: json["price"],
    );
  }
}
