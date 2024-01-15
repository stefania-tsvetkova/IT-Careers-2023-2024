SELECT username FROM users AS u
JOIN likes AS l
ON l.liked_user_id = u.user_id
GROUP BY u.user_id
ORDER BY COUNT(l.liked_by_user_id) DESC, user_id DESC
LIMIT 3;