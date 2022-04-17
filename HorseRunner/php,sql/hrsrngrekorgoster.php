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

$sql="SELECT * FROM hrsrngrekor";
$sorgu = mysqli_query($conn,$sql);

$sql2 = "SELECT * FROM hrsrngrekor ORDER BY rekor DESC";
$sorgu2 = mysqli_query($conn,$sql2);

while ($row = mysqli_fetch_assoc($sorgu2)) 
{ 
    $isim = $row["isim"];
    $rekor = $row["rekor"];
    $kisiler="$isim|$rekor|";
    echo $kisiler;
}



?>