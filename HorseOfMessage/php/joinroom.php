<?php
$servername = "92.205.12.157";
$database = "atlar";
$username = "talha";
$password = "Luna1park.";

// Create connection

//$conn = mysqli_connect($servername, $username, $password, $database);

$dbh = new PDO('mysql:host=92.205.12.157;dbname=horseofmessage', $username, $password);
$dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
$dbh->query("SET CHARACTER SET utf8");

// echo "Connected successfully";
$r = 0;
$roomname = $_POST['roomname'];
$roompass = $_POST['roompass'];
$personname = $_POST['personname'];
$message = $_POST['message'];

$stmt = $dbh->query("SELECT * FROM $roomname");

while ($row = $stmt->fetch()) {
        if ( $row['tablepass'] == $roompass){
            $r=1;
            $sql3 = $dbh->query("INSERT INTO $roomname (tablename, tablepass, personname, message) VALUES ('$roomname','$roompass','$personname','$message')");
        }
}

if($r == 1){
    echo "okey";
}


$dbh = null;
?>