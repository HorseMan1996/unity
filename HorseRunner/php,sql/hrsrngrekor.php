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
$puan = $_POST['rekorpuan'];
$para = $_POST['paramiz'];

$sql="SELECT * FROM hrsrngrekor";
$sorgu = mysqli_query($conn,$sql);

//$row = mysqli_fetch_assoc($result); 
        
/*while ($row = mysqli_fetch_assoc($sorgu)){
        $kontrolisim = $row["isim"];
        if($kontrolisim == $isim)
        {
            $eklendi = 1;
        }
}*/

       /* if ($eklendi != 1){
        $sql2 = "INSERT INTO hrsrngrekor (isim,rekor) VALUES ('$isim','$puan')";
        $sorgu3 = mysqli_query($conn,$sql2);
        }*/

/*while ($row = mysqli_fetch_assoc($sorgu)) 
{   
    $kontrolisim = $row["isim"];
    $sorgu2 = "UPDATE hrsrngrekor SET rekor='$puan' WHERE isim='$kontrolisim'";
    if(mysqli_query($conn, $sorgu2))
    {
        
    }
}*/

$sorgu5 = "UPDATE hrsrngrekor SET aktifmi=0,money='$para',rekor='$puan'  WHERE isim='$isim'";
mysqli_query($conn, $sorgu5);
    

/*while ($row = mysqli_fetch_assoc($sorgu)) {
        if($puan > $row["rekor"] && $isim == $row["isim"] && $eklendi == 0)
    {
        $yerdegisecekisim = $row["isim"];
        $sorgu2 = $conn->prepare("UPDATE hrsrngrekor SET isim = '$isim', rekorpuan = '$puan' WHERE isim = '$yerdegisecekisim'");
        $eklendi = 1;
    }
    
    if($puan > $row["rekor"] && $eklendi == 0)
    {
        $sql = "INSERT INTO hrsrngrekor (isim,rekor) VALUES ('$isim','$puan')";
        $sorgu2 = mysqli_query($conn,$sql);
        $eklendi = 1;
    }
    
}*/



    //    $guncellenecekkisi = $row["rekor"];
    //    $sorgu2 = $conn->prepare("UPDATE hrsrngrekor SET isim = '$isim', rekorpuan = '$puan' WHERE kisi_sira = $guncellenecekkisi");
        


//mysqli_free_result($sorgu2);
mysqli_free_result($sorgu);
mysqli_close($conn);
?>