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

$r=0;
$name = $_POST['name'];
$lastname = $_POST['lastname'];
$username = $_POST['username'];
$password = $_POST['password'];
$email = $_POST['email'];
$number = $_POST['numbers'];
$age = $_POST['age'];
$sex = $_POST['male'];
$firsttime = $_POST['firsttime'];

$stmt = $dbh->query("SELECT * FROM horseofmessengert");

while ($row = $stmt->fetch()) {
        if ( $row['number'] == $number){
            $r=1;
            echo "failed";
        }
}

if($r == 0){
    $sql = $dbh->query("INSERT INTO horseofmessengert (name, lastname, password, mail, number, age, gender, username, firstdate) VALUES ('$name','$lastname','$password','$email','$number','$age','$sex','$username','$firsttime')");
if($sql){
    echo "success";
    echo "|";
}
}


$stmt = null;
$dbh = null;
?>

