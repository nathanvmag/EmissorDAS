<?php 
set_time_limit(0);

if (isset($_POST["title"])&&isset($_POST["price"])&&isset($_POST["neg"])&&isset($_POST["dcurt"])&&isset($_POST["dlong"])
&&isset($_POST["end"])&&isset($_POST["num"])&&isset($_POST["cep"])&&isset($_POST["bairro"])&&isset($_POST["tipo"])
&&isset($_POST["taman"])&&isset($_GET["servID"])&&$_GET["servID"]==33)
{
	$title =$_POST["title"];
	$price =$_POST["price"];
	$neg   =$_POST["neg"];
	$dcurt= $_POST["dcurt"];	
	$dlong= $_POST["dlong"];
	$end= $_POST["end"];
	$num =$_POST["num"];
	$cep =$_POST["cep"];
	$bairro =$_POST["bairro"];
	$tipo =$_POST["tipo"];
	$taman =$_POST["taman"];
	$pics="";

	$local= $end.", ".$num.", ".$bairro.", ".$cep;

	$servername = "localhost";
    $username = "u938492100_natha";
    $pass = "24842288";
    $dbname ="u938492100_imvs";
    $connect = new mysqli($servername,$username,$pass,$dbname);
    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
    $sql2 = "SELECT MAX( id ) as 'max' FROM  `imoveis`WHERE 1";
    $result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));
    $myID;
    if(mysqli_num_rows($result) > 0)
	{
		while($row = mysqli_fetch_assoc($result))
		{
			$myID= $row["max"];
		}
	}
	$myID= intval($myID);
	$myID++;
	if (!file_exists("userimages/".$myID)) {
    mkdir("userimages/".$myID, 0775, true);
	}
   	for($i =0; $i < 12; $i++){
		  if (isset($_FILES["pic".$i]["name"])&& $_FILES["pic".$i]["name"]!="")
				{
					$filetmp =$_FILES["pic".$i]["tmp_name"];
					$filename = $_FILES["pic".$i]["name"];
					$filename= preg_replace('/\s+/', '', $filename);
					$destination = "userimages/".$myID."/".$filename;					
					
					if (move_uploaded_file($filetmp, $destination))
					{						
					}
					else {
						echo "<script>alert('Erro ao enviar fotos')</script>";
						die(mysql_error($connect));
					}
					if ($pics!=""){
						$pics = $pics."º".$destination;
					}
					else $pics = $destination;
			}
			
			}
			$pics= preg_replace('/\s+/', '', $pics);
			
	mysqli_close($connect);
	$connect = new mysqli($servername,$username,$pass,$dbname);
    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
	$sql = "INSERT INTO `imoveis` ( `titulo`, `preço`, `negocio`, `dpeq`, `dcomp`, `localiza`, `tipo`, `taman`, `imgs`) VALUES ('$title', '$price', '$neg', '$dcurt', '$dlong', '$local', '$tipo', '$taman', '$pics');";

	mysqli_query($connect, $sql) or die(mysqli_error($connect));
	echo "Sucesso";
	echo "<script>alert('Registrado com Sucesso') </script>";
	echo "<script>window.location = 'admin.php' </script>";
	//echo $pics;	
}
else if (isset($_POST["title"])&&isset($_POST["price"])&&isset($_POST["neg"])&&isset($_POST["dcurt"])&&isset($_POST["dlong"])
&&isset($_POST["end"])&&isset($_POST["num"])&&isset($_POST["cep"])&&isset($_POST["bairro"])&&isset($_POST["tipo"])
&&isset($_POST["taman"])&&isset($_GET["id"])&&isset($_GET["servID"])&&$_GET["servID"]==10)
{
	$title =$_POST["title"];
	$price =$_POST["price"];
	$neg   =$_POST["neg"];
	$dcurt= $_POST["dcurt"];	
	$dlong= $_POST["dlong"];
	$end= $_POST["end"];
	$num =$_POST["num"];
	$cep =$_POST["cep"];
	$bairro =$_POST["bairro"];
	$tipo =$_POST["tipo"];
	$taman =$_POST["taman"];
	$id=$_GET["id"];

	$local= $end.", ".$num.", ".$bairro.", ".$cep;

	$servername = "localhost";
    $username = "u938492100_natha";
    $pass = "24842288";
    $dbname ="u938492100_imvs";
    $connect = new mysqli($servername,$username,$pass,$dbname);
    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));   			

	$sql = "UPDATE `imoveis` SET `titulo`= '$title',`preço`= '$price',`negocio`= '$neg',`dpeq`= '$dcurt',`dcomp`= '$dlong',`localiza`= '$local',`tipo`= '$tipo',`taman`= '$taman' WHERE `id`= '$id'";
	mysqli_query($connect, $sql) or die(mysqli_error($conn));
	echo "Sucesso";
	echo "<script>alert('Alterado com Sucesso') </script>";
	echo "<script>window.location = 'admin.php' </script>";
	//echo $pics;	
	echo "aqui";
}
else if (isset($_POST['id'])&&isset($_GET['servID'])&&$_GET['servID']==46)

{
	$id = $_POST['id'];
	$servername = "localhost";
    $username = "u938492100_natha";
    $pass = "24842288";
    $dbname ="u938492100_imvs";
    $connect = new mysqli($servername,$username,$pass,$dbname);
    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
    $sql = "DELETE FROM `imoveis` WHERE `id` = $id";
    mysqli_query($connect, $sql) or die(mysqli_error($conn));
    
	echo "<script>alert('Excluido com Sucesso') </script>";
	echo "<script>window.location = 'admin.php' </script>";

}
else echo "erro";

 


 

?>