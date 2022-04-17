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
$eklendi = 0;
$isim = $_POST['isim'];
$sifre = $_POST['sifre'];

$sql="SELECT * FROM hrsrngrekor";
$sorgu = mysqli_query($conn,$sql);

while ($row = mysqli_fetch_assoc($sorgu)){
        $kontrolisim = $row["isim"];
        if($kontrolisim == $isim)
        {
            $eklendi = 1;
        }
}

if($eklendi == 1){
    echo "isimvar";
}
if($eklendi == 0){
$sql2 = "INSERT INTO hrsrngrekor (isim,password) VALUES ('$isim','$sifre')";
$sorgu3 = mysqli_query($conn,$sql2);
    echo "isimyok";
}

mysqli_free_result($sorgu);
mysqli_close($conn);
?>