<?php 


$dosya = fopen('horsefarmmessage.txt', 'r');
echo fgets($dosya); 
fclose($dosya);
?>