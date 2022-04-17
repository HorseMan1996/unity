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

$isim = $_POST['isim'];
$sifre = $_POST['sifre'];

$sql="SELECT * FROM hrsrngrekor";
$sorgu = mysqli_query($conn,$sql);

while ($row = mysqli_fetch_assoc($sorgu)){
        $kontrolisim = $row["isim"];
        $sifre2 = $row["password"];
        if(($kontrolisim == $isim) && ($sifre2 == $sifre))
        {
            echo $row["rekor"];
            echo "|";
            echo $row["money"];
            echo "|";
        }
}

echo "0";

mysqli_free_result($sorgu);
mysqli_close($conn);

?>