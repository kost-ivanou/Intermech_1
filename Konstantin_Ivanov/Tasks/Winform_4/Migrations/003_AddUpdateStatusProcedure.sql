DROP PROCEDURE IF EXISTS sp_UpdateStatus;

CREATE PROCEDURE sp_UpdateStatus(
    IN p_id INT,
    IN p_status VARCHAR(50)
)
BEGIN
    UPDATE files
    SET status = p_status
    WHERE id = p_id;
END;