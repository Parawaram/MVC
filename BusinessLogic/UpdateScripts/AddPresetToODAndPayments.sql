begin transaction;
go

alter table dbo.OrderDetails add
  PresetId int,
  constraint FK_OrderDetails_Presets foreign key(PresetId) references Presets(Id);
go

create table dbo.PaymentMethods(
  Id     int           not null identity constraint PK_PaymentMethods primary key,
  [Name] nvarchar(max) not null
);
go

commit;
go

GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 12/03/2014 15:44:56 ******/
SET IDENTITY_INSERT [dbo].[PaymentMethods] ON
INSERT [dbo].[PaymentMethods] ([Id], [Name]) VALUES (1, N'Visa')
INSERT [dbo].[PaymentMethods] ([Id], [Name]) VALUES (2, N'MasterCard')
INSERT [dbo].[PaymentMethods] ([Id], [Name]) VALUES (3, N'WebMoney')
INSERT [dbo].[PaymentMethods] ([Id], [Name]) VALUES (4, N'PayPal')
INSERT [dbo].[PaymentMethods] ([Id], [Name]) VALUES (5, N'ЕРИП')
INSERT [dbo].[PaymentMethods] ([Id], [Name]) VALUES (6, N'Безналичный расчет')
SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF
