import 'package:flutter/material.dart';
import 'package:appointit/pages/Home.dart';
import 'package:appointit/pages/Login.dart';
import 'package:appointit/pages/Recommend.dart';
import 'package:appointit/pages/Search.dart';
import 'package:appointit/pages/Terms.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Login(),
      routes: {
        '/home': (context) => Home(),
        '/search': (context) => Search(),
        '/recommend': (context) => Recommend()
      },
    );
  }
}
