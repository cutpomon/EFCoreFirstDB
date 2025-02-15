﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreFirstDB.Task
{
    public class Task_03
    {
        public static void Execute(AuctionContext db)
        {
            Console.WriteLine("Задание 3. Вывести список аукционов, с указанием суммарного дохода" + Environment.NewLine +
                "от продажи, отсортированных по доходу.");
            Console.WriteLine("----------------------------------------------------------------");

            #region Old
            //var data = from auction in db.Auctions
            //           join lot in db.Lots on auction.Id equals lot.AuctionId
            //           join item in db.Items on lot.ItemId equals item.Id
            //           select new
            //           {
            //               auction,
            //               item
            //           };
            //var result = data.GroupBy(a => a.auction.Name)
            //                 .Select(x => new
            //                 {
            //                     AuctionName = x.Key,
            //                     ItemSum = x.Sum(i => i.item.BuyPrice)
            //                 })
            //                 .OrderByDescending(x => x.ItemSum);

            //foreach (var auct in result)
            //{
            //    Console.WriteLine($"Аукцион: {auct.AuctionName}{Environment.NewLine}" +
            //        $"Сумма выручки: {auct.ItemSum}");
            //    Console.WriteLine();
            //}
            #endregion

            var result = db.Auctions
                .Select(x => new
                {
                    auctionName = x.Name,
                    itemSum = x.Lots.Sum(y => y.BuyPrice)
                });

            foreach (var auct in result)
            {
                Console.WriteLine($"Аукцион: {auct.auctionName}{Environment.NewLine}" +
                    $"Сумма выручки: {auct.itemSum}");
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
