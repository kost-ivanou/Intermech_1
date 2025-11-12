CREATE TABLE IF NOT EXISTS files (
    id INT AUTO_INCREMENT PRIMARY KEY,
    file_name VARCHAR(255),
    file_data LONGBLOB,
    total_bytes BIGINT,
    uploaded_bytes BIGINT,
    status VARCHAR(50)
);