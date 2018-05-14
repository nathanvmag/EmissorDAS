<?php 
require 'configs.php';
if(isset($_POST['url'])){
	ini_set('default_socket_timeout', 30);
	$url = $_POST['url'];
	echo file_get_contents($url);
}
else if ($servID==991)
	{
		if(isset($_POST['cnpj'])&&isset($_POST['mes'])&&isset($_POST['pago']))
		{
			$cnpj=$_POST['cnpj'];			
			$mes=$_POST['mes'];
			$pago=$_POST['pago'];
			$sts="";
			if ($pago=="1")
			{
				$sts="Pago";
			}
			else {
				$sts='Aguardando Pagamento';				
			}
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "UPDATE `emissoes` SET `pago`='$pago',`status`='$sts' WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
			mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			echo "OK";
		}
		else echo "error";
	}
	else echo "error";
 ?>