import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:appointit/models/MdlBaseUser.dart';
import 'package:appointit/models/MdlRecommend.dart';
import 'package:appointit/services/APIService.dart';

class Recommend extends StatefulWidget {
  @override
  _RecommendState createState() => _RecommendState();
}

Future<int?> fetchService() async {
  var service = await APIService.GetLast('GetLastService', null);
  if (service == null || service == 0) {
    return 0;
  }
  return service;
}

Future<List<MdlRecommend>> fetchRecommend() async {
  var service = await fetchService();
  if (service != 0) {
    var result = await APIService.GetListById('CustomerRecommender', service!);
    var recommend = result!.map((e) => MdlRecommend.fromJson(e)).toList();
    return recommend;
  }
  return [];
}

class _RecommendState extends State<Recommend> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Preporučeni proizvodi'),
        backgroundColor: Color.fromARGB(255, 89, 54, 244),
      ),
      body: LoadData(),
    );
  }
}

Widget LoadData() {
  return FutureBuilder<List<MdlRecommend>>(
    future: fetchRecommend(),
    builder:
        (BuildContext context, AsyncSnapshot<List<MdlRecommend>> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(child: CircularProgressIndicator());
      } else if (snapshot.data!.length == 0) {
        return Text("Nema dovoljno ocijenjenih usluga.");
      } else if (snapshot.hasError) {
        return Center(
          child: Text('Error...'),
        );
      } else {
        return ListView(
            children: snapshot.data!.map((e) => Kartica(e)).toList());
      }
    },
  );
}

Widget Kartica(MdlRecommend recommend) {
  return Card(
    child: ListTile(
      leading: Icon(Icons.check),
      tileColor: Color.fromARGB(255, 89, 183, 238),
      title: Text(
        recommend.name,
        style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
      ),
      subtitle: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            "Trajanje " + recommend.duration.toString() + " minuta.",
            style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
          ),
          Text(
            "Cijena: " + recommend.price.toString() + "KM",
            style: TextStyle(
              fontWeight: FontWeight.bold,
            ),
          ),
        ],
      ),
    ),
  );
}
