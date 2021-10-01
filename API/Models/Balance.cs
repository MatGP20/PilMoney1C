namespace API.Models
{
  using System;
  using System.Collections.Generic;

  public class Balance
  {
    public Balance()
    {
    }

    public Balance(int iD_Balance, int iD_Tipo_Cuenta, int balance)
    {
      this.ID_Balance = iD_Balance;
      this.ID_Tipo_Cuenta = iD_Tipo_Cuenta;
      this.Balance1 = balance;

    }

    public int ID_Balance { get; set; }
    public int ID_Tipo_Cuenta { get; set; }
    public int Balance1 { get; set; }

  }
}
