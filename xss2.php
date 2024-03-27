<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action="" method="post" >

    <?php 
    
    $word = $_POST['search'];
    
    
    
    ?>
    aranacak kelime:<input maxlength="600" type="text" placeholder="Search the blog..." name="search" value=<?php echo $word?>>
    <input type="submit" value="ara" name="submit">

    </form>

    <?php 
    
    echo "<br>"."aradıgınız kelime ".htmlspecialchars($word) ;
    
    ?>
</body>
</html>