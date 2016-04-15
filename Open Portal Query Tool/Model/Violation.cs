using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Open_Portal_Query_Tool.Model {
    public class Violation {

        [JsonProperty("additional_penalties_or_late_fees")]
        public decimal AdditionalPenaltiesOrLateFees { get; set; }

        [JsonProperty("balance_due")]
        public decimal BalanceDue { get; set; }

        [JsonProperty("charge_1_code")]
        public string Charge1Code { get; set; }

        [JsonProperty("charge_1_code_description")]
        public string Charge1CodeDescription { get; set; }

        [JsonProperty("charge_1_code_section")]
        public string Charge1CodeSection { get; set; }

        [JsonProperty("charge_1_infraction_amount")]
        public decimal Charge1InfractionAmount { get; set; }

        [JsonProperty("compliance_status")]
        public string ComplianceStatus { get; set; }

        [JsonProperty("decision_date")]
        public DateTime DecisionDate { get; set; }

        [JsonProperty("hearing_date")]
        public DateTime HearingDate { get; set; }

        [JsonProperty("hearing_result")]
        public string HearingResult { get; set; }

        [JsonProperty("hearing_status")]
        public string HearingStatus { get; set; }

        [JsonProperty("hearing_time")]
        public string HearingTime { get; set; }

        [JsonProperty("issuing_agency")]
        public string IssuingAgency { get; set; }

        [JsonProperty("paid_amount")]
        public decimal PaidAmount { get; set; }

        [JsonProperty("penalty_imposed")]
        public decimal PenaltyImposed { get; set; }

        [JsonProperty("respondent_address_borough")]
        public string RespondentAddressBorough { get; set; }

        [JsonProperty("respondent_address_city")]
        public string RespondentAddressCity { get; set; }

        [JsonProperty("respondent_address_house")]
        public string RespondentAddressHouse { get; set; }

        [JsonProperty("respondent_address_state_name")]
        public string RespondentAddressStateName { get; set; }

        [JsonProperty("respondent_address_street_name")]
        public string RespondentAddressStreetName { get; set; }

        [JsonProperty("respondent_address_zip_code")]
        public string RespondentAddressZipCode { get; set; }

        [JsonProperty("respondent_first_name")]
        public string RespondentFirstName { get; set; }

        [JsonProperty("respondent_last_name")]
        public string RespondentLastName { get; set; }

        [JsonProperty("scheduled_hearing_location")]
        public string ScheduledHearingLocation { get; set; }

        [JsonProperty("ticket_number")]
        public string TicketNumber { get; set; }

        [JsonProperty("total_violation_amount")]
        public decimal TotalViolationAmount { get; set; }

        [JsonProperty("violation_date")]
        public DateTime ViolationDate { get; set; }

        [JsonProperty("violation_details")]
        public string ViolationDetails { get; set; }

        [JsonProperty("violation_location_block_no")]
        public string ViolationLocationBlockNo { get; set; }

        [JsonProperty("violation_location_borough")]
        public string ViolationLocationBorough { get; set; }

        [JsonProperty("violation_location_city")]
        public string ViolationLocationCity { get; set; }

        [JsonProperty("violation_location_house")]
        public string ViolationLocationHouse { get; set; }

        [JsonProperty("violation_location_lot_no")]
        public string ViolationLocationLotNo { get; set; }

        [JsonProperty("violation_location_state_name")]
        public string ViolationLocationStateName { get; set; }

        [JsonProperty("violation_location_street_name")]
        public string ViolationLocationStreetName { get; set; }

        [JsonProperty("violation_location_zip_code")]
        public string ViolationLocationZipCode { get; set; }

        [JsonProperty("violation_time")]
        public string ViolationTime { get; set; }

       /* public override bool Equals(object o) {
            return this.TicketNumber == ((Violation)o).TicketNumber;
        */
    }

    
}
