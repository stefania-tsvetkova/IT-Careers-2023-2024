-- Solution 1
-- SELECT 
--     u2.username AS liked_by,
--     u1.username AS liked,
--     cu2.value AS liked_by_eye_color,
--     cu1.value AS liked_eye_color
-- FROM likes AS l
-- JOIN users AS u1
-- ON u1.user_id = l.liked_user_id
-- JOIN users AS u2
-- ON u2.user_id = l.liked_by_user_id
-- JOIN characteristics AS c
-- ON c.title = 'Eye color'
-- JOIN characteristics_users AS cu1
-- ON cu1.user_id = u1.user_id AND cu1.characteristic_id = c.characteristic_id
-- JOIN characteristics_users AS cu2
-- ON cu2.user_id = u2.user_id AND cu2.characteristic_id = c.characteristic_id
-- ORDER BY liked_by, liked
-- LIMIT 5;

SELECT 
    u2.username AS liked_by,
    u1.username AS liked,
    cu2.value AS liked_by_eye_color,
    cu1.value AS liked_eye_color
FROM likes AS l
JOIN users AS u1
ON u1.user_id = l.liked_user_id
JOIN users AS u2
ON u2.user_id = l.liked_by_user_id
JOIN characteristics_users AS cu1
ON 
    cu1.user_id = u1.user_id AND 
    cu1.characteristic_id = (
        SELECT characteristic_id FROM characteristics
        WHERE title = 'Eye color'
    )
JOIN characteristics_users AS cu2
ON 
    cu2.user_id = u2.user_id AND 
    cu2.characteristic_id = (
        SELECT characteristic_id FROM characteristics
        WHERE title = 'Eye color'
    )
ORDER BY liked_by, liked
LIMIT 5;