SELECT from_user_id, to_user_id, accepted FROM connections
WHERE from_user_id = 481 AND accepted = TRUE
ORDER BY to_user_id DESC;