DROP PROCEDURE IF EXISTS sp_UpdateFileChunk;

CREATE PROCEDURE sp_UpdateFileChunk(
    IN p_id INT,
    IN p_chunk LONGBLOB,
    IN p_len BIGINT
)
BEGIN
    UPDATE files
    SET file_data = IFNULL(CONCAT(file_data, p_chunk), p_chunk),
        uploaded_bytes = uploaded_bytes + p_len
    WHERE id = p_id;
END;