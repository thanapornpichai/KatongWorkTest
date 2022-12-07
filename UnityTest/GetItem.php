<?php
require 'ConnectionSettings.php';

//variables submited by user
$itemID = $_POST["itemID"];

if($conn->connect_error){
    die("Connection failed: ".$conn->connect_error);
}

$sql = "SELECT name,description,price FROM items WHERE ID = '" . $itemID . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    $rows = array();
    while($row = $result->fetch_assoc()) {
      $rows[] = $row;
    }
    echo json_encode($rows);
  } else {
    echo "0";
  }
$conn->close();

?>