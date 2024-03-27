<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action="" method="post">
        sitenizi giriniz: <input type="text" name="site" id="">
    </form>

    <?php 
    $site = htmlspecialchars($_POST['site']);
    echo '<a href="' . $site . '">' . "siteniz" . '</a>';
    
    ?>
</body>
</html>