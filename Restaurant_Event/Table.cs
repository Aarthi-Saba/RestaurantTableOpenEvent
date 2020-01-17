using System;

namespace Restaurant_Event
{
    class Table
    {
        public event Notify TableOpen;
        public void OpenTableforCust()
        {
            if(TableOpen != null)
            {
                TableOpen(this, EventArgs.Empty);
            }
        }
    }
    public delegate void Notify(object Table, EventArgs args);

    public class TableOpenEventHandler
    {
        public void TableOpenMessage(object Table,EventArgs args)
        {
            Console.WriteLine("Table is Open !");
        }
    }
}
