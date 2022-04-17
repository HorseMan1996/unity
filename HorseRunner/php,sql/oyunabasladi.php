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

$isim = $_POST['isim'];

$sorgu2 = "UPDATE hrsrngrekor SET aktifmi=1 WHERE isim='$isim'";
$sorgu3 = mysqli_query($conn, $sorgu2);
    
    
mysqli_close($conn);
?>