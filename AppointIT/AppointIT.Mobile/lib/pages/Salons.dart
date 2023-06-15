import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:flutter/material.dart';
import 'package:appointit/models/MdlNews.dart';
import 'package:appointit/models/MdlSalon.dart';
import 'package:appointit/pages/alert_dialog_widget.dart';
import 'package:appointit/pages/Home.dart';
import 'package:appointit/pages/MapScreen.dart';
import 'package:appointit/services/APIService.dart';
import 'package:jiffy/jiffy.dart';

import '../models/MdlBaseUser.dart';
import '../models/MdlSalonRating.dart';

class Salon extends StatefulWidget {
  final int salonId;
  const Salon({Key? key, required this.salonId}) : super(key: key);

  @override
  _SalonState createState() => _SalonState();
}

Future<List<MdlNews>> fetchNews(salonId) async {
  Map<String, String> queryParams = {'SalonId': salonId.toString()};
  var news = await APIService.Get('News', queryParams);
  return news!.map((e) => MdlNews.fromJson(e)).toList();
}

Future<MdlSalon> fetchSalon(salonId) async {
  var salon = await APIService.GetById('Salon', salonId);
  return MdlSalon.fromJson(salon);
}

Future<int?> fetchCustomer() async {
  Map<String, String> queryParams = {'Email': APIService.username};
  var user = await APIService.Get('Customer', queryParams);
  return user!.map((e) => MdlBaseUser.fromJson(e)).first.id;
}

class _SalonState extends State<Salon> {
  List<MdlSalonRating> ratings = [];
  double initRating = 0;

  Future loadRating() async {
    var ocjena = await APIService.Get('SalonService', null);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
          title: Text('Salon'),
          backgroundColor: Color.fromARGB(255, 89, 54, 244),
          leading: IconButton(
            icon: Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.of(context).pop();
            },
          )),
      body: Column(
        children: [
          FutureBuilder<MdlSalon>(
              future: fetchSalon(widget.salonId),
              builder:
                  (BuildContext context, AsyncSnapshot<MdlSalon> snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return Center(
                    child: CircularProgressIndicator(),
                  );
                } else if (snapshot.hasError) {
                  return Center(
                    child: Text('Error...'),
                  );
                } else {
                  return Center(
                    child: Image.memory(
                      Uint8List.fromList(snapshot.data!.photo),
                      height: 230,
                    ),
                  );
                }
              }),
          SizedBox(
            height: 20,
          ),
          Table(
            border: TableBorder(
                verticalInside: BorderSide(
                    width: 1.0, color: Colors.black, style: BorderStyle.solid)),
            children: [
              TableRow(children: [
                InkWell(
                    onTap: () async {
                      MdlSalon salon = await fetchSalon(widget.salonId);
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => Mape(
                                longitude: salon.lat, latitude: salon.lng)),
                      );
                    },
                    child: Icon(Icons.location_on)),
                Icon(Icons.favorite),
                InkWell(
                    onTap: () {
                      Navigator.of(context).popAndPushNamed('/home');
                    },
                    child: Icon(Icons.home)),
              ]),
            ],
          ),
          Padding(
            padding: EdgeInsets.symmetric(vertical: 30),
            child: Column(
              children: [
                Text(
                  'Ocjenite salon:',
                  style: TextStyle(
                    fontSize: 20,
                    decoration: TextDecoration.overline,
                    color: Colors.black,
                  ),
                ),
                SizedBox(height: 10),
                _buildRating(),
              ],
            ),
          ),
          Padding(
            padding: EdgeInsets.symmetric(vertical: 30),
            child: Text(
              'Posljednje novosti',
              style: TextStyle(
                  fontSize: 20,
                  decoration: TextDecoration.underline,
                  color: Colors.grey[700]),
            ),
          ),
          Expanded(
            child: FutureBuilder<List<MdlNews>>(
                future: fetchNews(widget.salonId),
                builder: (BuildContext context,
                    AsyncSnapshot<List<MdlNews>> snapshot) {
                  if (snapshot.connectionState == ConnectionState.waiting) {
                    return Center(
                      child: CircularProgressIndicator(),
                    );
                  } else if (snapshot.hasError) {
                    return Center(
                      child: Text('Error...'),
                    );
                  } else {
                    return ListView(
                        children: snapshot.data!
                            .map((e) => novost(e, context))
                            .toList());
                  }
                }),
          ),
        ],
      ),
    );
  }

  Center _buildRating() {
    return Center(
        child: RatingBar.builder(
            initialRating: initRating,
            minRating: 1,
            direction: Axis.horizontal,
            allowHalfRating: true,
            itemCount: 5,
            itemPadding: EdgeInsets.symmetric(horizontal: 4.0),
            itemBuilder: (context, _) => Icon(
                  Icons.star,
                  color: Color.fromARGB(255, 192, 164, 79),
                ),
            onRatingUpdate: (rating) async {
              if (ratings.isEmpty) {
                Map ratingInsert = {
                  "rating": rating.toDouble(),
                  "customerId": await fetchCustomer(),
                  "salonId": widget.salonId,
                };

                try {
                  await APIService.Post('SalonRating', ratingInsert);

                  await showDialog(
                      context: context,
                      builder: (BuildContext dialogContex) => AlertDialogWidget(
                            title: "Uspješno!",
                            message:
                                "Vaša ocjena za ovaj salon uspješno je dodana.",
                            context: dialogContex,
                          ));
                } catch (e) {
                  showDialog(
                      context: context,
                      builder: (BuildContext dialogContex) => AlertDialogWidget(
                            title: "Error",
                            message: "An error occured!",
                            context: dialogContex,
                          ));
                }
              } else {
                Map ratingInsert = {
                  "rating": rating.toDouble(),
                  "customerId": await fetchCustomer(),
                  "salonId": widget.salonId,
                };

                try {
                  await APIService.Put('SalonRating',
                      ratings.first.salonRatingId!, ratingInsert);

                  await showDialog(
                      context: context,
                      builder: (BuildContext dialogContex) => AlertDialogWidget(
                            title: "Izmjena uspješna!",
                            message:
                                "Vaša ocjena za ovaj salon uspješno je izmjenjena.",
                            context: dialogContex,
                          ));

                  setState(() {});
                } catch (e) {
                  showDialog(
                      context: context,
                      builder: (BuildContext dialogContex) => AlertDialogWidget(
                            title: "Error",
                            message: "An error occured!",
                            context: dialogContex,
                          ));
                }
              }
            }));
  }
}

Widget novost(MdlNews news, BuildContext context) {
  var date = Jiffy(news.createdAt).yMMMMd; // October 18, 2019
  return Column(children: [
    Container(
        height: 120,
        width: MediaQuery.of(context).size.width * 0.95,
        decoration:
            BoxDecoration(border: Border.all(color: Colors.black, width: 1.0)),
        child: Row(children: [
          Align(
            alignment: Alignment.centerLeft,
            child: Image.memory(
              Uint8List.fromList(news.photo),
              width: 150,
              height: 100,
            ),
          ),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.end,
              children: [
                SizedBox(
                  height: 30,
                ),
                Text(
                  news.title,
                  style: TextStyle(fontSize: 20, color: Colors.black38),
                ),
                Text(
                  date,
                  style: TextStyle(
                    fontSize: 13,
                  ),
                )
              ],
            ),
          ),
        ])),
    SizedBox(
      height: 20,
    )
  ]);
}
