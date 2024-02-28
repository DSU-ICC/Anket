﻿namespace DomainService.DtoModels.enums
{
    public enum TypeOperationMode
    {
        Default, // Обычный режим при котором берутся дисциплины за прошлый курс
        Yearly, // Режим при котором берутся дисциплины за заданной период с ежегодным повтореним
        Other // Режим при котором дата начала и дата окончания берутся из базы неизменными
    }
}
