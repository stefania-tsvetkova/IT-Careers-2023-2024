-- Solution 1
-- SELECT user_id, username, first_name, last_name FROM users AS u
-- LEFT JOIN likes AS l
-- ON l.liked_user_id = u.user_id
-- WHERE l.liked_user_id IS NULL
-- ORDER BY first_name, last_name
-- LIMIT 10;

-- Solution 2
SELECT user_id, username, first_name, last_name FROM users AS u
WHERE (
    SELECT COUNT(*) FROM likes AS l
    WHERE l.liked_user_id = u.user_id
) = 0
ORDER BY first_name, last_name
LIMIT 10;