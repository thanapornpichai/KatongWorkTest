<?php
require 'ConnectionSettings.php';

$userid = $_POST["userid"];

if($conn->connect_error){
    die("Connection failed: ".$conn->connect_error);
}
//echo "Connected successfully, now we will show the users.<br><br>";

$sql = "SELECT fbname FROM accounts WHERE userid = '" . $userid . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo $row["fbname"];
  }
} else {
  echo "0 results";
}
$conn->close();

?>