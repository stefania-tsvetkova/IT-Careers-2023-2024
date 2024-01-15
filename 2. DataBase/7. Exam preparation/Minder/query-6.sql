SELECT 
    ROUND(AVG(cu.value), 2) AS 'average_height'
FROM characteristics_users AS cu
JOIN characteristics AS c
ON c.title = 'Height' AND cu.characteristic_id = c.characteristic_id;