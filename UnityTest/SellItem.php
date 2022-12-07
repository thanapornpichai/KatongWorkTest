<?php
require 'ConnectionSettings.php';

//variables submited by user
$itemID = $_POST["itemID"];
$userID = $_POST["userID"];
$wishes = $_POST["wishes"];

if($conn->connect_error){
    die("Connection failed: ".$conn->connect_error);
}

$sql = "SELECT coins FROM accounts WHERE userid = '" . $userID . "'";

$coins = $conn->query($sql);

$sql6 = "SELECT cash FROM accounts WHERE userid = '" . $userID . "'";

$cash = $conn->query($sql6);

$sql2 = "SELECT price FROM items WHERE ID = '" . $itemID . "'";

$price = $conn->query($sql2);

$userCoins = $coins->fetch_assoc()["coins"];
$userCash = $cash->fetch_assoc()["cash"];
$itemPrice = $price->fetch_assoc()["price"];

if($itemPrice == 0){
  $sql3 = "SELECT ID FROM usersitems WHERE userID = '" . $userID . "' AND itemID = 1";

  $free = $conn->query($sql3);
  if ($free->num_rows > 0) {
    echo "already free.";
  }else{
    $sql4 = "INSERT INTO usersitems (userID,itemID,wishes) VALUES ('" . $userID . "','" . $itemID . "','" . $wishes . "')";

    $result = $conn->query($sql4);
  }
}else{
  if($itemPrice == 30){
    if ($userCash >= $itemPrice) {

      $sql4 = "INSERT INTO usersitems (userID,itemID,wishes) VALUES ('" . $userID . "','" . $itemID . "','" . $wishes . "')";
  
      $result = $conn->query($sql4);
      if($result){
          $sql5 = "UPDATE `accounts` SET `cash`= cash-'" . $itemPrice . "' WHERE `userid` = '" . $userID . "'";
          $conn->query($sql5);
      }
      else{
          echo "could not buy item.";
      }
    }else{
      echo "no money.";
    }
  }else{
if ($userCoins >= $itemPrice) {

    $sql4 = "INSERT INTO usersitems (userID,itemID,wishes) VALUES ('" . $userID . "','" . $itemID . "','" . $wishes . "')";

    $result = $conn->query($sql4);
    if($result){
        $sql5 = "UPDATE `accounts` SET `coins`= coins-'" . $itemPrice . "' WHERE `userid` = '" . $userID . "'";
        $conn->query($sql5);
    }
    else{
        echo "could not buy item.";
    }
  }else{
    echo "no money.";
  }
}
}

$conn->close();

?>