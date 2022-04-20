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

$number = $_POST['phone'];
$password = $_POST['password'];

$stmt = $dbh->query("SELECT * FROM horseofmessengert");

while ($row = $stmt->fetch()) {
    if ( $row['number'] == $number){
            if ( $row['password'] == $password){
                echo "success";
                echo "|";
                echo $row['name'];
                echo "|";
                echo $row['lastname'];               
                echo "|";
                echo $row['password'];
                echo "|";
                echo $row['email'];
                echo "|";
                echo $row['number'];
                echo "|";
                echo $row['age'];
                echo "|";
                echo $row['male'];
                echo "|";
                echo $row['username'];
                echo "|";
        }
    }

}


$dbh = null;
?>