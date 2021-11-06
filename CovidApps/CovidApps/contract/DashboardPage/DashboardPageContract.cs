using CovidApps.database;
using CovidApps.json.covid19;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.contract.DashboardPage
{
    public interface IView
    {
        void OnGetRecordSuccess(List<JsonCovidRecord> covidRecords);
        void OnFailure(string error);
    }
    public interface IModel
    {
        void getCovidRecord(IOnListerner listerner);
    }

    public interface IPresenter
    {
        void getCovidRecord();
    }
    public interface IOnListerner
    {
        void OnGetRecordSuccess(List<JsonCovidRecord> covidRecords);
        void OnFailure(string error);
    }
}
