<?php 

$text = $_POST["who"];

$dosya = fopen('horsefarmmessage.txt', 'a');
fwrite($dosya, $text);

fclose($dosya);
?>