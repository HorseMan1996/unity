<?php
$servername = "92.205.12.157";
$database = "horseofmessage";
$username = "talha";
$password = "Luna1park.";

// Create connection

//$conn = mysqli_connect($servername, $username, $password, $database);

$dbh = new PDO('mysql:host=92.205.12.157;dbname=horseofmessage', $username, $password);
$dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
$dbh->query("SET CHARACTER SET utf8");
// echo "Connected successfully";

$i = 1;
$roomname = $_POST['roomname'];
$personname = $_POST['personname'];
$writemessage = $_POST['write'];

$sql3 = $dbh->query("INSERT INTO $roomname (personname, message) VALUES ('$personname','$writemessage')");




$dbh = null;
?>