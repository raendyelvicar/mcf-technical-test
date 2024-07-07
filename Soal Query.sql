--1
Primary Key:
TglPembayaran (Tabel Pembayaran)
KodeCabang (Tabel Cabang)
KodeMotor (Tabel Motor)

Foreign Key:
KodeCabang dan KodeMotor (Tabel Pembayaran)

-- 2
SELECT * 
FROM Pembayaran 
WHERE TglBayar = '20-10-2014';

-- 3
INSERT INTO Cabang(KodeCabang, NamaCabang) VALUES('200', 'Tangerang';

--4
UPDATE Pembayaran 
SET KodeMotor = '001' 
WHERE KodeCabang = '115';

--5
SELECT 
    p.NoKontrak, 
    p.TglBayar, 
    p.JumlahBayar, 
    p.KodeCabang, 
    c.NamaCabang, 
    p.NoKwitansi, 
    p.KodeMotor,  
    m.NamaMotor 
FROM 
    Pembayaran as p 
JOIN 
    Cabang c ON c.KodeCabang = p.KodeCabang
JOIN 
    Motor m On m.KodeMotor =  p.KodeMotor

-- 6
SELECT 
    c.KodeCabang, 
    c.NamaCabang, 
    p.NoKontrak, 
    p.No.Kwitansi
FROM 
    Cabang c
LEFT JOIN 
    Pembayaran p ON p.KodeCabang = c.KodeCabang

--7
SELECT 
    c.KodeCabang, 
    c.NamaCabang, 
    COALESCE(COUNT(p.NoKontrak), 0), 
    COALESCE(SUM(p.JumlahBayar),0)
FROM 
    Cabang c
JOIN 
    Pembayaran p On p.KodeCabang = c.KodeCabang
GROUP BY 
    c.KodeCabang, c.NamaCabang;


