<?php
require 'ConnectionSettings.php';

//User submited variables
$userID = $_POST["userID"];

if($conn->connect_error){
    die("Connection failed: ".$conn->connect_error);
}

$sql = "SELECT friendID FROM userfriends WHERE userID = '" . $userID . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  //$rows = array();
  while($row = $result->fetch_assoc()) {
    echo $row["friendID"];

  }
  //echo json_encode($rows);
} else {
  echo "No friend.";
}
$conn->close();

?>