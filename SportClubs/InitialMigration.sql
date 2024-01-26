INSERT INTO public."Faculties"(
"Name")
VALUES ('Инженердик');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Комуникация');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Гуманитардык');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Экономика жана башкаруу');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Табигый илимдер');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Көркөм өнөр');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Теология');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Спорт илимдери');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Туризм');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Ветеринария');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Айыл чарба');
INSERT INTO public."Faculties"(
"Name")
VALUES ('Кесиптик колледж');

-- departments

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Компьютер', 1);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Электроника жана электр', 1);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Өнөр-жай', 1);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Тамак-аш', 1);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Химия', 1);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Экология', 1);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Журналистика', 2);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Коом менен байланыш жана реклама', 2);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Радио, телевидение жана кино', 2);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Педагогика', 3);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Философия', 3);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Филология', 3);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Синхрондук котормо', 3);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Социология', 3);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Тарых', 3);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Түркология', 3);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Эл аралык мамилелер', 4);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Экономика', 4);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Менеджмент', 4);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Биология', 5);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Математика', 5);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Колдонмо математика жана информатика', 5);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Графика', 6);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Музыка', 6);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Живопись', 6);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Театралдык искусство', 6);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Диндерди таануу', 7);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Ислам таануу', 7);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Машыктыруучуларды даярдоо', 8);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Дене тарбия жана спорт мугалими', 8);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Ресторан иши жана кулинардык өнөр', 9);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Саякат иши жана гид кызматы', 9);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Туризм жана мейманкана ишмердүүлүгү', 9);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Ветеринария', 10);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Мөмө-жемиш жана талаа өсүмдүктөрү', 11);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Өсүмдүктөрдү коргоо', 11);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Зоотехния', 11);

INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Техникалык программалары', 12);
INSERT INTO public."Departments"(
"Name", "FacultyId")
VALUES ('Экономика жана башкаруу программалары', 12);

INSERT INTO public."Announcements"(
"Title", "Description", "Photo", "Date")
VALUES ( 'test title', 'test descr', E'\\x0123456789ABCDEF', CURRENT_DATE);
