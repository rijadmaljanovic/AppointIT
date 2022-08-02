import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:appointit/models/MdlCategory.dart';
import 'package:appointit/models/MdlServices.dart';
import 'package:appointit/pages/MojiTermini.dart';
import 'package:appointit/pages/Search.dart';
import 'package:appointit/pages/Terms.dart';
import 'package:appointit/services/APIService.dart';

import 'Coupons.dart';

class Home extends StatefulWidget {
  @override
  _HomeState createState() => _HomeState();
}

bool clicked = false;
Future<List<MdlCategory>> fetchCategories() async {
  var categories = await APIService.Get('Category', null);
  return categories!.map((e) => MdlCategory.fromJson(e)).toList();
}

Future<List<MdlServices>> fetchServices(categoryId) async {
  Map<String, String> queryParams = {'CategoryId': categoryId.toString()};
  var services = await APIService.Get('Service', queryParams);
  return services!.map((e) => MdlServices.fromJson(e)).toList();
}

class _HomeState extends State<Home> {
  Widget kartica(MdlCategory category, size) {
    return Column(
      children: [
        SizedBox(
          height: 20,
        ),
        ExpansionTile(
          expandedAlignment: Alignment.bottomLeft,
          textColor: Color.fromARGB(255, 89, 54, 244),
          trailing: SizedBox.shrink(),
          title: Container(
            decoration: BoxDecoration(
              color: Colors.white30,
              border: Border.all(
                color: clicked == true
                    ? Color.fromARGB(255, 89, 54, 244)
                    : Colors.grey,
              ),
              // borderRadius: BorderRadius.circular(15),
            ),
            height: 100,
            child: Row(children: [
              Image(
                  width: 150,
                  height: 150,
                  image: Image.memory(
                    Uint8List.fromList(category.photo),
                  ).image),
              Text(
                category.name,
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 21),
              ),
            ]),
          ),
          children: [categoryServices(category.id)],
        ),
      ],
    );
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Scaffold(
      appBar: AppBar(
          title: Text('Home'),
          backgroundColor: Color.fromARGB(255, 79, 95, 240)),
      bottomNavigationBar: BottomNavigationBar(
        onTap: (id) {
          if (id == 1) {
            Navigator.of(context)
                .push(MaterialPageRoute(builder: (context) => Search()));
          }
          if (id == 2) {
            Navigator.of(context)
                .push(MaterialPageRoute(builder: (context) => Coupons()));
          }
          if (id == 3) {
            Navigator.of(context)
                .push(MaterialPageRoute(builder: (context) => MojiTermini()));
          }
        },
        type: BottomNavigationBarType.fixed,
        // backgroundColor: Colors.black54,
        items: [
          BottomNavigationBarItem(icon: Icon(Icons.home), label: 'Home'),
          BottomNavigationBarItem(
            icon: Icon(Icons.search),
            label: 'Pretraga',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.card_giftcard),
            label: 'Kuponi',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.date_range),
            label: 'Moji termini',
          ),
        ],
      ),
      body: FutureBuilder<List<MdlCategory>>(
        future: fetchCategories(),
        builder:
            (BuildContext context, AsyncSnapshot<List<MdlCategory>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(child: CircularProgressIndicator());
          } else if (snapshot.hasError) {
            return Center(child: CircularProgressIndicator());
          } else {
            return ListView(
                children: snapshot.data!.map((e) => kartica(e, size)).toList());
          }
        },
      ),
    );
  }
}

Widget categoryServices(int categoryId) {
  return FutureBuilder<List<MdlServices>>(
    future: fetchServices(categoryId),
    builder: (BuildContext context, AsyncSnapshot<List<MdlServices>> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(child: CircularProgressIndicator());
      } else if (snapshot.hasError) {
        return Center(child: CircularProgressIndicator());
      } else {
        return Container(
          height: 100,
          child: SingleChildScrollView(
            physics: BouncingScrollPhysics(),
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: snapshot.data!
                    .map((e) => Padding(
                        padding: EdgeInsets.only(top: 5, left: 30),
                        child: Text(
                          e.name.toString(),
                          style: TextStyle(
                              decoration: TextDecoration.underline,
                              fontSize: 15,
                              fontWeight: FontWeight.bold),
                        )))
                    .toList()),
          ),
        );
      }
    },
  );
}
