--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1 (Debian 13.1-1.pgdg100+1)
-- Dumped by pg_dump version 13.1 (Debian 13.1-1.pgdg100+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: brand; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA brand;


ALTER SCHEMA brand OWNER TO postgres;

--
-- Name: product; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA product;


ALTER SCHEMA product OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: brand; Type: TABLE; Schema: brand; Owner: postgres
--

CREATE TABLE brand.brand (
    id integer NOT NULL,
    name text
);


ALTER TABLE brand.brand OWNER TO postgres;

--
-- Name: brand_id_seq; Type: SEQUENCE; Schema: brand; Owner: postgres
--

ALTER TABLE brand.brand ALTER COLUMN id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME brand.brand_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: size; Type: TABLE; Schema: brand; Owner: postgres
--

CREATE TABLE brand.size (
    id integer NOT NULL,
    "rusSize" text,
    "brandSize" text,
    "brandId" integer NOT NULL
);


ALTER TABLE brand.size OWNER TO postgres;

--
-- Name: size_id_seq; Type: SEQUENCE; Schema: brand; Owner: postgres
--

ALTER TABLE brand.size ALTER COLUMN id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME brand.size_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: product; Type: TABLE; Schema: product; Owner: postgres
--

CREATE TABLE product.product (
    id integer NOT NULL,
    name text,
    "brandId" integer NOT NULL,
    "brandName" text,
    "rusSize" text
);


ALTER TABLE product.product OWNER TO postgres;

--
-- Name: product_id_seq; Type: SEQUENCE; Schema: product; Owner: postgres
--

ALTER TABLE product.product ALTER COLUMN id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME product.product_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: brand; Type: TABLE DATA; Schema: brand; Owner: postgres
--

COPY brand.brand (id, name) FROM stdin;
1	тестовый бренд 1
2	тестовый бренд 2
3	Тестовый брэнд 3
4	Тестовый брэнд 4
\.


--
-- Data for Name: size; Type: TABLE DATA; Schema: brand; Owner: postgres
--

COPY brand.size (id, "rusSize", "brandSize", "brandId") FROM stdin;
1	Маленький	S	1
\.


--
-- Data for Name: product; Type: TABLE DATA; Schema: product; Owner: postgres
--

COPY product.product (id, name, "brandId", "brandName", "rusSize") FROM stdin;
1	Тестовый продукт 1	1	тестовый бренд 1	Маленький
2	Тестовый продукт 2	1	тестовый бренд 1	Маленький
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20210810215951_Initial	5.0.8
\.


--
-- Name: brand_id_seq; Type: SEQUENCE SET; Schema: brand; Owner: postgres
--

SELECT pg_catalog.setval('brand.brand_id_seq', 4, true);


--
-- Name: size_id_seq; Type: SEQUENCE SET; Schema: brand; Owner: postgres
--

SELECT pg_catalog.setval('brand.size_id_seq', 1, true);


--
-- Name: product_id_seq; Type: SEQUENCE SET; Schema: product; Owner: postgres
--

SELECT pg_catalog.setval('product.product_id_seq', 2, true);


--
-- Name: brand brandBrandPK; Type: CONSTRAINT; Schema: brand; Owner: postgres
--

ALTER TABLE ONLY brand.brand
    ADD CONSTRAINT "brandBrandPK" PRIMARY KEY (id);


--
-- Name: size brandSizePK; Type: CONSTRAINT; Schema: brand; Owner: postgres
--

ALTER TABLE ONLY brand.size
    ADD CONSTRAINT "brandSizePK" PRIMARY KEY (id);


--
-- Name: product productProductPK; Type: CONSTRAINT; Schema: product; Owner: postgres
--

ALTER TABLE ONLY product.product
    ADD CONSTRAINT "productProductPK" PRIMARY KEY (id);


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_size_brandId; Type: INDEX; Schema: brand; Owner: postgres
--

CREATE INDEX "IX_size_brandId" ON brand.size USING btree ("brandId");


--
-- Name: size FK_size_brand_brandId; Type: FK CONSTRAINT; Schema: brand; Owner: postgres
--

ALTER TABLE ONLY brand.size
    ADD CONSTRAINT "FK_size_brand_brandId" FOREIGN KEY ("brandId") REFERENCES brand.brand(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

