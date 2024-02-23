use("accountManagementDB");

db.createCollection("userAccounts");

db.getCollection("userAccounts").insertMany([
  {
    userID: UUID("12400388-9af4-4ab2-a31e-eb902da686cb"),
    accountID: UUID("dd2246fc-55f8-4a71-97f6-1b162735162b"),
    balance: 345.125,
    transactions: [
      {
        transactionID: UUID("7d7ac3f3-0d3d-4726-9115-89acba6fb895"),
        type: "Charge",
        amount: 11.6,
        timestamp: new Date("2023-05-18T19:15:30Z"),
      },
      {
        transactionID: UUID("1e291050-881b-4df0-b924-b9dcf135a6aa"),
        type: "Charge",
        amount: 20.1,
        timestamp: new Date("2024-01-18T14:10:12Z"),
      },
      {
        transactionID: UUID("0c7be92f-9535-46c8-80c5-befc66ae5d71"),
        type: "Charge",
        amount: 4.0,
        timestamp: new Date("2020-05-18T17:10:30Z"),
      },
    ],
  },
  {
    userID: UUID("36801706-ca2d-4897-b731-61e751066014"),
    accountID: UUID("8cf88231-4db6-477b-aa23-eb35854d3b14"),
    balance: 12.65,
    transactions: [
      {
        transactionID: UUID("a026d231-d125-4278-89a5-e5967517ca8c"),
        type: "Charge",
        amount: 1.05,
        timestamp: new Date("2024-02-22T14:10:12Z"),
      },
    ],
  },
]);
