SELECT u.username FROM users AS u
JOIN characteristics_users AS cu
ON cu.user_id = u.user_id
JOIN characteristics AS c
ON c.characteristic_id = cu.characteristic_id AND c.title = 'Eye color'
WHERE 
    u.gender = 'f' AND
    cu.value = 'blue' AND 
    u.birthdate >= '1990-01-01' AND 
    u.birthdate <= '1999-12-31'
ORDER BY u.username DESC;