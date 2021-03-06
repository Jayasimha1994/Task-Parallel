﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//using System.Diagnostics;
//using System.Net.Sockets;

//namespace TaskParallelProject
//{
//    /// <summary>
//    /// class with Two fields neccessory for all transactions.
//    /// </summary>
//    public class Account
//    {
//        double _balance;
//        int _id;
//        /// <summary>
//        /// constructor for initializing the two instance fields.
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="balance"></param>
//        public Account(int id, double balance)
//        {
//            this._id = id; this._balance = balance;
//        }
//        /// <summary>
//        /// Property for only read access.
//        /// </summary>
//        public int ID
//        {
//            get { return _id; }
//        }
//        /// <summary>
//        /// Method for withdrawl status.
//        /// </summary>
//        /// <param name="amount"></param>
//        public void Withdraw(double amount)
//        {
//            _balance -= amount;
//        }
//        /// <summary>
//        /// method for the deposit.
//        /// </summary>
//        /// <param name="amount"></param>
//        public void Deposit(double amount)
//        {
//            _balance += amount;
//        }
//    }
//    /// <summary>
//    /// Class which involves in all accounts transactions.
//    /// </summary>
//    public class AccountManager
//    {
//        Account _fromAccount; Account _toAccount; double _amountToTransfer;
//        /// <summary>
//        /// constructor for initializing the fields.
//        /// </summary>
//        /// <param name="fromAccount"></param>
//        /// <param name="toAccount"></param>
//        /// <param name="amountToTransfer"></param>
//        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
//        {
//            this._fromAccount = fromAccount;
//            this._toAccount = toAccount;
//            this._amountToTransfer = amountToTransfer;
//        }
//        /// <summary>
//        /// for transffering the ammount.
//        /// </summary>
//        public void Transfer()
//        {
//            object _lock1, _lock2;
//            if (_fromAccount.ID < _fromAccount.ID)
//            {
//                _lock1 = _fromAccount;
//                _lock2 = _fromAccount;
//            }
//            else
//            {
//                _lock1 = _fromAccount;
//                _lock2 = _fromAccount;
//            }
//            Console.WriteLine(Thread.CurrentThread.Name + " trying to aquire lock on " + ((Account)_lock1).ID.ToString());
//            lock (_lock1)
//            {
//                Console.WriteLine(Thread.CurrentThread.Name + " aquired lock on " + ((Account)_lock1).ID.ToString());
//                Console.WriteLine(Thread.CurrentThread.Name + " suspended for 1 sec");
//                Thread.Sleep(1000);
//                Console.WriteLine(Thread.CurrentThread.Name + " back in action and trying to aquire lock on " + ((Account)_lock2).ID.ToString());
//                lock (_lock2)
//                {
//                    Console.WriteLine(Thread.CurrentThread.Name + " aquired lock on " + ((Account)_lock2).ID.ToString());
//                    _fromAccount.Withdraw(_amountToTransfer);
//                    _toAccount.Deposit(_amountToTransfer);
//                    Console.WriteLine(Thread.CurrentThread.Name + " Transfered " + _amountToTransfer.ToString() + " from " + _fromAccount.ID.ToString() + " to " + _toAccount.ID.ToString());
//                }
//            }
//        }
//    }
//    /// <summary>
//    /// class to perform transactions by creating objects.
//    /// perfom the given task by assigning thread to the task.
//    /// </summary>
//    public class DeadLockResolve
//    {
//        static void StartTrasaction()
//        {
//            Account accountA = new Account(101, 5000);
//            Account accountB = new Account(102, 3000);

//            AccountManager accountmanagerA = new AccountManager(accountA, accountB, 1000);
//            Thread t1 = new Thread(accountmanagerA.Transfer);
//            t1.Name = "T1";
//            AccountManager accountmanagerB = new AccountManager(accountB, accountA, 2000);
//            Thread t2 = new Thread(accountmanagerB.Transfer);
//            t2.Name = "T2";
//            t1.Start();
//            t2.Start();
//            t1.Join();
//            t2.Join();
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Main Started");
//            StartTrasaction();
//            Console.WriteLine("main completed");
//            Console.Read();
//        }
//    }
//}
