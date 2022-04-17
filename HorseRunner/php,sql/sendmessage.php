<?php
$servername = "92.205.12.157";
$database = "atlar";
$username = "talha";
$password = "Luna1park.";

// Create connection

$conn = mysqli_connect($servername, $username, $password, $database);

// Check connection
if (!$conn) {
    die("Connection failed: " . 
mysqli_connect_error());
}
// echo "Connected successfully";


$username = $_POST['name'];
$message = $_POST['message'];

$sql2 = "INSERT INTO sendmessage (isim,mesaj) VALUES ('$username','$message')";
$sorgu3 = mysqli_query($conn,$sql2);

?>