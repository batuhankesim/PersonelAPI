--veritabanı ve tablo

CREATE DATABASE PersonelVeritabani;
GO

USE PersonelVeritabani;

CREATE TABLE personel (
    sicilnumarasi INT PRIMARY KEY,
    ad NVARCHAR(50),
    soyad NVARCHAR(50),
    departmankodu INT,
    departmanadi NVARCHAR(50),
    isegiristarihi DATE,
    istencikistarihi DATE,
    eposta NVARCHAR(100),
    cinsiyet NVARCHAR(10),
    gsmtelefon NVARCHAR(10),
    telefonsabit NVARCHAR(10)
);

--kayitlar atiliyor
INSERT INTO [PersonelVeritabani].[dbo].[personel] (sicilnumarasi, ad, soyad, departmankodu, departmanadi, isegiristarihi, istencikistarihi, eposta, cinsiyet, gsmtelefon, telefonsabit)
VALUES
(1001, 'Arzu', 'Ayvaz', 4510, 'İktisat', '1989-08-14', '2009-08-31', 'ayv@tskb.com.tr', 'Kadın', '5325556703', '2123340001'),
(1002, 'Nüket', 'Demircan', 4910, 'Uygulama Geliştirme', '1990-12-03', NULL, 'demir@tskb.com.tr', 'Kadın', '5325556708', NULL),
(1003, 'Kemal', 'Görgeç', 4930, 'Bina İşletim ve İdari İşler', '1988-05-02', NULL, 'gor@tskb.com.tr', 'Erkek', '5325556689', '2123340003'),
(1004, 'Akın', 'Süel', 4600, 'Genel Sekreterlik', '2010-10-01', '2015-12-31', 'suel@tskb.com.tr', 'Erkek', '5325556671', '2123340004'),
(1005, 'Mine', 'Orhan', 4420, 'Menkul Kıymetler', '1989-02-23', '2008-02-29', 'anm@tskb.com.tr', 'Kadın', '5325556700', NULL),
(1006, 'Rahmi', 'Yıldırım', 4410, 'Hazine', '1991-05-07', NULL, 'yildir@tskb.com.tr', 'Erkek', '5325556709', NULL),
(1007, 'Şahin', 'Arslan', 4930, 'Bina İşletim ve İdari İşler', '2008-03-01', NULL, 'ars@tskb.com.tr', 'Erkek', '5325556669', '2123340007'),
(1008, 'Nazlı', 'Sarıdağ', 4930, 'Bina İşletim ve İdari İşler', '1988-02-23', '2008-02-29', 'ee@tskb.com.tr', 'Kadın', '5325556682', NULL),
(1009, 'Nurhan', 'Palak', 4930, 'Bina İşletim ve İdari İşler', '1988-03-01', NULL, 'akn@tskb.com.tr', 'Kadın', '5325556683', '2123340009'),
(1012, 'Hasan', 'Altun', 4930, 'Bina İşletim ve İdari İşler', '1988-04-19', NULL, 'tunh@tskb.com.tr', 'Erkek', '5325556687', '2123340012'),
(1013, 'Müslüm', 'Erdoğan', 4930, 'Bina İşletim ve İdari İşler', '2011-12-01', NULL, 'ganmu@tskb.com.tr', 'Erkek', '5325556701', '2123340013'),
(1014, 'Enise', 'Ahlatlı', 4930, 'Bina İşletim ve İdari İşler', '1989-10-13', '2009-10-13', 'latlie@tskb.com.tr', 'Kadın', '5325556704', NULL),
(1015, 'Rauf', 'Özkan', 4610, 'Hukuk İşleri', '2008-08-01', '2008-10-17', 'kanr@tskb.com.tr', 'Erkek', '5325556670', '2123340015'),
(1016, 'Ufuk', 'Özkan', 4014, 'İç Kontrol', '1989-02-01', '2012-07-31', 'kanu@tskb.com.tr', 'Erkek', '5325556697', '2123340016'),
(1017, 'Aslıhan', 'Emlek', 4930, 'Bina İşletim ve İdari İşler', '1988-03-01', '2008-03-31', 'ggg@tskb.com.tr', 'Kadın', '5325556685', '2123340017'),
(1018, 'Funda', 'Gürel', 4740, 'Kurumsal Pazarlama', '1989-08-07', '2014-04-30', 'gurelf@tskb.com.tr', 'Kadın', '5325556702', NULL),
(1019, 'Korkut', 'Ün', 4530, 'Mali Analiz ve Değerleme', '1992-08-24', '2012-05-08', 'unk@tskb.com.tr', 'Erkek', '5325556713', '2123340019'),
(1020, 'Erdal', 'Bayrak', 5930, 'Hazine ve Sermaye Piyasası Operasyonları', '1989-02-21', NULL, 'ayrak@tskb.com.tr', 'Erkek', '5325556699', '2123340020'),
(1021, 'Özcan', 'Dorman', 4930, 'Bina İşletim ve İdari İşler', '2006-03-01', '2014-12-31', 'vbnn@tskb.com.tr', 'Erkek', '5325556672', '2123340021'),
(1022, 'Ahmet', 'Ersin', 4930, 'Bina İşletim ve İdari İşler', '2009-02-01', '2011-12-31', 'rsina@tskb.com.tr', 'Erkek', '5325556679', '2123340022'),
(1023, 'Bülent', 'Yazaroğlu', 4930, 'Bina İşletim ve İdari İşler', '2005-01-01', NULL, 'lll@tskb.com.tr', 'Erkek', '5325556688', NULL),
(1024, 'Şaban', 'Karagöz', 4930, 'Bina İşletim ve İdari İşler', '1989-01-02', NULL, 'kara@tskb.com.tr', 'Erkek', '5325556696', '2123340024'),
(1025, 'Hamza', 'Özdemir', 4930, 'Bina İşletim ve İdari İşler', '1990-02-22', '2014-01-31', 'klj@tskb.com.tr', 'Erkek', '5325556705', '2123340025'),
(1026, 'Eser Çelik', 'Ün', 4620, 'Vakıf', '1990-12-03', '2012-12-21', 'elike@tskb.com.tr', 'Kadın', '5325556706', '2123340026'),
(1027, 'Bekir', 'Sucu', 4920, 'Sistem Destek ve İletişim', '1986-09-01', '2007-11-30', 'cub@tskb.com.tr', 'Erkek', '5325556674', NULL),
(1028, 'Neslihan', 'Gerçek', 6410, 'Kurumsal Mimari ve Süreç Yönetimi', '1990-12-03', '2015-10-06', 'cekn@tskb.com.tr', 'Kadın', '5325556707', '2123340028'),
(1029, 'Nurgül', 'Kösoğlu', 4620, 'Vakıf', '1987-09-17', '2008-01-31', 'yyy@tskb.com.tr', 'Kadın', '5325556677', '2123340029'),
(1030, 'Kamuran', 'Kuş', 4410, 'Hazine', '1988-12-13', NULL, 'kusk@tskb.com.tr', 'Kadın', '5325556694', '2123340030'),
(1031, 'Nur', 'Gülpınar', 5910, 'Kredi Operasyonları', '1989-02-15', NULL, 'gulp@tskb.com.tr', 'Kadın', '5325556698', NULL);

-- seq

CREATE SEQUENCE SicilNumarasiSequence
START WITH 1032 -- son değer
INCREMENT BY 1;

CREATE PROCEDURE prs_i_personel
	@sicilnumarasi INT OUTPUT,
    @ad NVARCHAR(50),
    @soyad NVARCHAR(50),
    @departmankodu int,
    @departmanadi NVARCHAR(50),
    @isegiristarihi DATE,
    @istencikistarihi DATE,
    @eposta NVARCHAR(100),
    @cinsiyet NVARCHAR(10),
    @gsmtelefon NVARCHAR(20),
    @telefonsabit NVARCHAR(20)
AS
BEGIN
    SELECT @sicilnumarasi = NEXT VALUE FOR SicilNumarasiSequence;

    INSERT INTO [PersonelVeritabani].[dbo].[personel] (sicilnumarasi, ad, soyad, departmankodu, departmanadi, isegiristarihi, istencikistarihi, eposta, cinsiyet, gsmtelefon, telefonsabit)
    VALUES (@sicilnumarasi, @ad, @soyad, @departmankodu, @departmanadi, @isegiristarihi, @istencikistarihi, @eposta, @cinsiyet, @gsmtelefon, @telefonsabit);
END;


CREATE PROCEDURE prs_u_personel
    @sicilnumarasi INT,
    @ad NVARCHAR(50),
    @soyad NVARCHAR(50),
    @departmankodu INT,
    @departmanadi NVARCHAR(50),
    @isegiristarihi DATE,
    @istencikistarihi DATE,
    @eposta NVARCHAR(100),
    @cinsiyet NVARCHAR(10),
    @gsmtelefon NVARCHAR(20),
    @telefonsabit NVARCHAR(20)
AS
BEGIN
    UPDATE [PersonelVeritabani].[dbo].[personel]
    SET ad = @ad, soyad = @soyad, departmankodu = @departmankodu, departmanadi = @departmanadi,
        isegiristarihi = @isegiristarihi, istencikistarihi = @istencikistarihi, eposta = @eposta,
        cinsiyet = @cinsiyet, gsmtelefon = @gsmtelefon, telefonsabit = @telefonsabit
    WHERE sicilnumarasi = @sicilnumarasi;
END;
-----------------------------------------------
CREATE PROCEDURE prs_d_personel
    @sicilnumarasi INT
AS
BEGIN
    DELETE FROM [PersonelVeritabani].[dbo].[personel] WHERE sicilnumarasi = @sicilnumarasi;
END;

-----------------------------------------------
CREATE PROCEDURE prs_s_personel
	@sicilnumarasi INT
AS
BEGIN
    SELECT * FROM [PersonelVeritabani].[dbo].[personel] WHERE sicilnumarasi = @sicilnumarasi;
END;
-----------------------------------------------
CREATE PROCEDURE prs_l_personeltum
AS
BEGIN
    SELECT * FROM [PersonelVeritabani].[dbo].[personel];
END;

-----------------------------------------------
CREATE PROCEDURE prs_l_personel
	 @departmankodu INT,
	 @isegiristarihi DATE
AS
BEGIN
    SELECT * FROM [PersonelVeritabani].[dbo].[personel] 
	WHERE departmankodu = @departmankodu 
	AND isegiristarihi >= @isegiristarihi;
END;