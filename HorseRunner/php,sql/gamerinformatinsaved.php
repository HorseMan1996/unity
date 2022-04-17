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

$conn->set_charset("utf8");

$username = $_POST['username'];
$firstname = $_POST['firstname'];
$lastname = $_POST['lastname'];
$mail = $_POST['mail'];
$tel = $_POST['tel'];




$sql2 = "INSERT INTO hrsngmrinf (username,realfirstname,reallastname,mailadress,telephone) VALUES ('$username','$firstname','$lastname','$mail','$tel')";
$sorgu3 = mysqli_query($conn,$sql2);


$sql="SELECT * FROM hrsrngrekor";
$sorgu = mysqli_query($conn,$sql);


$sorgu2 = "UPDATE hrsrngrekor SET information=1 WHERE isim='$username'";
$sorgu4 = mysqli_query($conn, $sorgu2);

if($sorgu4){
    echo "successful";
}
else{
    echo "unsuccessful";
}

mysqli_close($conn);
        
?>