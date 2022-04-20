<?php
$servername = "92.205.12.157";
$database = "atlar";
$username = "talha";
$password = "Luna1park.";

// Create connection

$dbh = new PDO('mysql:host=92.205.12.157;dbname=horseofmessage', $username, $password);
$dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
$dbh->query("SET CHARACTER SET utf8");
// echo "Connected successfully";

$roomname = $_POST['roomname'];
$roompass = $_POST['roompass'];
$personname = $_POST['personname'];
$message = $_POST['message'];

$sql ="CREATE TABLE $roomname(
     tablename VARCHAR(20) NOT NULL, 
     tablepass VARCHAR(20) NOT NULL,
     personname VARCHAR(350) NOT NULL, 
     message VARCHAR(350) NOT NULL)";
     
     $sql2 = $dbh->query($sql);

     $sql3 = $dbh->query("INSERT INTO $roomname (tablename, tablepass, personname, message) VALUES ('$roomname','$roompass','$personname','$message')");

if($sql3){
    echo "okey";
}



$dbh = null;
?>