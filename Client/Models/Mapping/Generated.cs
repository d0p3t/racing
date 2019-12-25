using System;
using Newtonsoft.Json;

namespace Client.Models.Mapping
{

    public class Map
    {
        public int debugOnlyVersion { get; set; }
        public Meta meta { get; set; }
        public Mission mission { get; set; }
    }

    public class Meta
    {
        [JsonProperty("ems")]
        public bool IsEmsEnabled { get; set; }

        [JsonProperty("loc")]
        public string[] Zones { get; set; }
        public object[] mrule { get; set; }
        public object[] stia { get; set; }
        public object[] stia2 { get; set; }
        public object[] stinv { get; set; }
        public int[] veh { get; set; }

        [JsonProperty("vehcl")]
        public string[] VehicleClasses { get; set; }
        
        [JsonProperty("wp")]
        public object[] VehicleWeaponPickupHashes { get; set; }

        [JsonProperty("wpcl")]
        public object[] VehicleWeaponPickupModelNames { get; set; }
    }

    public class Mission
    {
        [JsonProperty("dhprop")]
        public Dhprop DeleteProps { get; set; }

        [JsonProperty("dprop")]
        public Dprop DynamicProps { get; set; } // dynamic props?
        public Endcon endcon { get; set; }
        public Ene ene { get; set; }
        public Fsp fsp { get; set; }

        [JsonProperty("gen")]
        public Gen Generated { get; set; } // huge class. perhaps contains camera positions for lobby. also descriptions for what looksl ike the race itself. so could very well be lobby stuff. also contains the name etc
        public Obj obj { get; set; }
        public Otzone otzone { get; set; }

        [JsonProperty("prop")]
        public PropData PropData { get; set; }
        public Ptemp ptemp { get; set; } // definitely used. has some hashes and vectors. vectors are very small though so some offsets?
       
        [JsonProperty("race")]
        public Race RaceData { get; set; }

        [JsonProperty("rule")]
        public Rule Rules { get; set; }
        public Usj usj { get; set; }

        [JsonProperty("veh")]
        public Veh VehicleData { get; set; }
        public Vhrls vhrls { get; set; }

        [JsonProperty("weap")]
        public Weap Weapons { get; set; }
        public Zone zone { get; set; }
    }

    public class Dhprop
    {
        public int[] bits { get; set; }
        public int[] mn { get; set; }
        public int no { get; set; }
        public Pos[] pos { get; set; }
    }

    public class Pos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Dprop
    {
        public int[] asso { get; set; }
        public int[] asso2 { get; set; }
        public int[] asso3 { get; set; }
        public int[] asso4 { get; set; }
        public int[] asss { get; set; }
        public int[] asss2 { get; set; }
        public int[] asss3 { get; set; }
        public int[] asss4 { get; set; }
        public int[] asst { get; set; }
        public int[] asst2 { get; set; }
        public int[] asst3 { get; set; }
        public int[] asst4 { get; set; }
        public int[] dpcl { get; set; }
        public int[] dprorc { get; set; }
        public int[] dpsl { get; set; }
        public int[] dptrRS { get; set; }
        public float[] dptrpx { get; set; }
        public int[] dyipbtt { get; set; }
        public int[] dyipho { get; set; }
        public int[] dynrpil { get; set; }

        [JsonProperty("head")]
        public float[] Heading { get; set; }

        [JsonProperty("loc")]
        public Loc[] Locations { get; set; }

        [JsonProperty("model")]
        public int[] ModelName { get; set; }

        [JsonProperty("no")]
        public int Total { get; set; }
        public int[] obref { get; set; }
        public int[] pasc { get; set; }
        public int[] pasc2 { get; set; }
        public int[] pasc3 { get; set; }
        public int[] pasc4 { get; set; }
        public int[] prcra { get; set; }
        public int[] prpbs { get; set; }
        public int[] prpcr { get; set; }
        public int[] prpct { get; set; }

        [JsonProperty("prpdclr")]
        public int[] PropVariation { get; set; }
        public int[] prpkt { get; set; }

        [JsonProperty("vRot")]
        public Vrot[] Rotations { get; set; }
    }

    public class Loc
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vrot
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Endcon
    {
        public int[] _2spar { get; set; }
        public int[] _2spwia { get; set; }
        public int[] abits { get; set; }
        public object[] airoha0 { get; set; }
        public object[] airola0 { get; set; }
        public object[] airset0 { get; set; }
        public object[] airsft0 { get; set; }
        public object[] airsid0 { get; set; }
        public object[] airsod0 { get; set; }
        public object[] airsodx0 { get; set; }
        public object[] airsr0 { get; set; }
        public object[] airssp0 { get; set; }
        public object[] airstv0 { get; set; }
        public object[] airtyp0 { get; set; }
        public int[] arear { get; set; }
        public object[] armr0 { get; set; }
        public int[] arrt { get; set; }
        public object[] artlit0 { get; set; }
        public object[] aumx0 { get; set; }
        public object[] bd2r0 { get; set; }
        public object[] bd2t0 { get; set; }
        public object[] bd2v0 { get; set; }
        public object[] bd2v10 { get; set; }
        public object[] bd2v20 { get; set; }
        public object[] bd2w0 { get; set; }
        public object[] bdprt0 { get; set; }
        public object[] bdpst0 { get; set; }
        public object[] bfm0 { get; set; }
        public int[] bla { get; set; }
        public int[] bla2 { get; set; }
        public object[] blolt0 { get; set; }
        public object[] bmbtm0 { get; set; }
        public object[] bmhok0 { get; set; }
        public object[] bmhrgn0 { get; set; }
        public object[] bmmdm0 { get; set; }
        public object[] bmmph0 { get; set; }
        public object[] bmmxh0 { get; set; }
        public object[] bmsjd0 { get; set; }
        public object[] bmspm0 { get; set; }
        public object[] bmstd0 { get; set; }
        public int[] bnd2 { get; set; }
        public object[] bosth0 { get; set; }
        public object[] bosti0 { get; set; }
        public int[] boud { get; set; }
        public object[] bsthr0 { get; set; }
        public object[] bundel0 { get; set; }
        public object[] bundel20 { get; set; }
        public object[] cap0 { get; set; }
        public object[] cbmanr0 { get; set; }
        public object[] cojc0 { get; set; }
        public object[] cojr0 { get; set; }
        public object[] critw0 { get; set; }
        public int[] cstrn { get; set; }
        public string[] csttn { get; set; }
        public object[] cwt0 { get; set; }
        public object[] dcont0 { get; set; }
        public object[] delpos { get; set; }
        public int[] delr { get; set; }
        public object[] destr0 { get; set; }
        public object[] destv0 { get; set; }
        public object[] destv20 { get; set; }
        public object[] destv30 { get; set; }
        public object[] destw0 { get; set; }
        public object[] diagwf0 { get; set; }
        public object[] diawfm0 { get; set; }
        public object[] diswp0 { get; set; }
        public object[] dlor0 { get; set; }
        public int[] dogps { get; set; }
        public object[] dops0 { get; set; }
        public object[] dost0 { get; set; }
        public object[] dotim0 { get; set; }
        public object[] dov0 { get; set; }
        public object[] dovd0 { get; set; }
        public object[] dpos0 { get; set; }
        public object[] dpos20 { get; set; }
        public object[] dpost0 { get; set; }
        public int[] dr { get; set; }
        public object[] drnRt0 { get; set; }
        public object[] drnmss0 { get; set; }
        public object[] drnn0 { get; set; }
        public object[] drno0 { get; set; }
        public object[] drnp0 { get; set; }
        public object[] drnpl0 { get; set; }
        public object[] drnr10 { get; set; }
        public object[] drnr20 { get; set; }
        public object[] drnr30 { get; set; }
        public object[] drnr40 { get; set; }
        public object[] drnv0 { get; set; }
        public object[] drph0 { get; set; }
        public object[] drpr0 { get; set; }
        public object[] dsosui0 { get; set; }
        public int[] edobs { get; set; }
        public object[] emonR0 { get; set; }
        public int[] endr { get; set; }
        public Epos[] epos { get; set; }
        public int[] fail { get; set; }
        public object[] fail0 { get; set; }
        public object[] fceStlth0 { get; set; }
        public object[] filtlh0 { get; set; }
        public object[] fkwl0 { get; set; }
        public object[] fleer0 { get; set; }
        public object[] fleev0 { get; set; }
        public int[] flmbs { get; set; }
        public object[] frndf0 { get; set; }
        public object[] fsdtmr0 { get; set; }
        public int[] fwoabs { get; set; }
        public object[] gacc0 { get; set; }
        public object[] gbaie0 { get; set; }
        public object[] gbat0 { get; set; }
        public object[] gbaw0 { get; set; }
        public object[] gbcol0 { get; set; }
        public object[] gbdel0 { get; set; }
        public object[] gbfnr0 { get; set; }
        public object[] gblgm0 { get; set; }
        public object[] gblgn0 { get; set; }
        public object[] gbmax0 { get; set; }
        public int[] gbmbs { get; set; }
        public object[] gbngm0 { get; set; }
        public object[] gbngn0 { get; set; }
        public object[] gbnum0 { get; set; }
        public object[] gbtp0 { get; set; }
        public object[] gbv10 { get; set; }
        public object[] gbv20 { get; set; }
        public object[] gbvhl0 { get; set; }
        public object[] gfld0 { get; set; }
        public object[] gpsdp0 { get; set; }
        public object[] grclp0 { get; set; }
        public object[] grkil0 { get; set; }
        public object[] grtug0 { get; set; }
        public object[] grwep0 { get; set; }
        public object[] hddstra0 { get; set; }
        public object[] hdmfp0 { get; set; }
        public object[] hitsnd0 { get; set; }
        public object[] hlm00 { get; set; }
        public object[] hlm01 { get; set; }
        public object[] hlm010 { get; set; }
        public object[] hlm011 { get; set; }
        public object[] hlm012 { get; set; }
        public object[] hlm013 { get; set; }
        public object[] hlm014 { get; set; }
        public object[] hlm015 { get; set; }
        public object[] hlm016 { get; set; }
        public object[] hlm017 { get; set; }
        public object[] hlm018 { get; set; }
        public object[] hlm019 { get; set; }
        public object[] hlm02 { get; set; }
        public object[] hlm03 { get; set; }
        public object[] hlm04 { get; set; }
        public object[] hlm05 { get; set; }
        public object[] hlm06 { get; set; }
        public object[] hlm07 { get; set; }
        public object[] hlm08 { get; set; }
        public object[] hlm09 { get; set; }
        public object[] hscr0 { get; set; }
        public object[] icmsk10 { get; set; }
        public object[] icmsk20 { get; set; }
        public object[] icmsk30 { get; set; }
        public int[] inpts { get; set; }
        public int[] inv { get; set; }
        public int[] inv2 { get; set; }
        public int[] inv2rl { get; set; }
        public int[] inv2tm { get; set; }
        public int[] inv3 { get; set; }
        public object[] invor0 { get; set; }
        public int[] invrl { get; set; }
        public int[] invsw { get; set; }
        public int[] invtm { get; set; }
        public object[] irbs0 { get; set; }
        public object[] irbs100 { get; set; }
        public object[] irbs110 { get; set; }
        public object[] irbs120 { get; set; }
        public object[] irbs130 { get; set; }
        public object[] irbs20 { get; set; }
        public object[] irbs30 { get; set; }
        public object[] irbs40 { get; set; }
        public object[] irbs50 { get; set; }
        public object[] irbs60 { get; set; }
        public object[] irbs70 { get; set; }
        public object[] irbs80 { get; set; }
        public object[] irbs90 { get; set; }
        public int[] ireveh { get; set; }
        public object[] irfbs0 { get; set; }
        public object[] iroamtr0 { get; set; }
        public object[] isvhr0 { get; set; }
        public object[] isvmg0 { get; set; }
        public object[] isvro0 { get; set; }
        public object[] itpreqs0 { get; set; }
        public object[] itved0 { get; set; }
        public object[] itvsd0 { get; set; }
        public object[] ivms0 { get; set; }
        public object[] ivmsa0 { get; set; }
        public object[] ivmsac0 { get; set; }
        public object[] ivmsb0 { get; set; }
        public object[] ivmse0 { get; set; }
        public object[] ivmsh0 { get; set; }
        public object[] ivmst0 { get; set; }
        public object[] lbblu0 { get; set; }
        public object[] lbgre0 { get; set; }
        public object[] lbred0 { get; set; }
        public int[] ldsf1 { get; set; }
        public int[] ldsf2 { get; set; }
        public object[] lnkdr0 { get; set; }
        public object[] lnkdr20 { get; set; }
        public object[] lvbs0 { get; set; }
        public int[] lwbs { get; set; }
        public int[] lwmbs { get; set; }
        public int[] mcgbs1 { get; set; }
        public int[] mcgbs2 { get; set; }
        public int[] mcgbs3 { get; set; }
        public object[] mcmp0 { get; set; }
        public int[] mcobs { get; set; }
        public int[] mcpbs1 { get; set; }
        public int[] mcpbs2 { get; set; }
        public int[] mcpbs3 { get; set; }
        public object[] mcry0 { get; set; }
        public object[] mcsrm0 { get; set; }
        public object[] mcstr0 { get; set; }
        public int[] mcvbs { get; set; }
        public object[] mdmr0 { get; set; }
        public object[] mgdm0 { get; set; }
        public object[] minspd0 { get; set; }
        public int[] minv { get; set; }
        public int[] minv2 { get; set; }
        public int[] minv3 { get; set; }
        public int[] mlpd { get; set; }
        public int[] mlpl { get; set; }
        public int[] mlpm { get; set; }
        public float[] mmi2m0 { get; set; }
        public int[] mmiam20 { get; set; }
        public int[] mmiam2t0 { get; set; }
        public float[] mmim0 { get; set; }
        public int[] mmsw { get; set; }
        public int[] mmsw2 { get; set; }
        public int[] mnumpt { get; set; }
        public object[] mnvhhl0 { get; set; }
        public object[] mnvhsd0 { get; set; }
        public object[] mnvhsi0 { get; set; }
        public object[] mnvms0 { get; set; }
        public object[] mors0 { get; set; }
        public object[] mpaib0 { get; set; }
        public object[] mpaib20 { get; set; }
        public object[] mpaumx0 { get; set; }
        public object[] mpaumxscr0 { get; set; }
        public object[] mpftmr0 { get; set; }
        public object[] mpot00 { get; set; }
        public object[] mpot10 { get; set; }
        public object[] mpot20 { get; set; }
        public object[] mrtl0 { get; set; }
        public int[] mslr { get; set; }
        public object[] mspdlp0 { get; set; }
        public object[] mspdmx0 { get; set; }
        public object[] mspdsv0 { get; set; }
        public int[] mtlr { get; set; }
        public int[] mts { get; set; }
        public object[] mwdmr0 { get; set; }
        public object[] mxhth0 { get; set; }
        public object[] mxwl0 { get; set; }
        public int[] nora { get; set; }
        public int[] nrl { get; set; }
        public int[] numpt { get; set; }
        public int[] obdr { get; set; }
        public int[] obkr { get; set; }
        public int[] ocl { get; set; }
        public object[] opl00 { get; set; }
        public object[] opl10 { get; set; }
        public object[] opl20 { get; set; }
        public object[] opl30 { get; set; }
        public object[] oplbs0 { get; set; }
        public object[] out2bh0 { get; set; }
        public object[] out2bs0 { get; set; }
        public object[] out2et0 { get; set; }
        public object[] out2fp0 { get; set; }
        public object[] out2hc0 { get; set; }
        public object[] out2hv0 { get; set; }
        public object[] out2id0 { get; set; }
        public object[] out2ilv0 { get; set; }
        public object[] out2io0 { get; set; }
        public object[] out2iv0 { get; set; }
        public object[] out2mm0 { get; set; }
        public object[] out2onfv0 { get; set; }
        public object[] out2sg0 { get; set; }
        public object[] out2wg0 { get; set; }
        public object[] outb0 { get; set; }
        public object[] outb1v0 { get; set; }
        public object[] outb2v0 { get; set; }
        public object[] outbh0 { get; set; }
        public object[] outbs0 { get; set; }
        public object[] outbt0 { get; set; }
        public object[] outclo0 { get; set; }
        public object[] outclp0 { get; set; }
        public object[] outclr0 { get; set; }
        public object[] outeid0 { get; set; }
        public object[] outety0 { get; set; }
        public object[] outfp0 { get; set; }
        public object[] outhc0 { get; set; }
        public object[] outhv0 { get; set; }
        public object[] outilv0 { get; set; }
        public object[] outiwo0 { get; set; }
        public object[] outiwv0 { get; set; }
        public object[] outmm0 { get; set; }
        public object[] outonfv0 { get; set; }
        public object[] outr0 { get; set; }
        public object[] outsg0 { get; set; }
        public object[] outw0 { get; set; }
        public object[] outwtg0 { get; set; }
        public object[] ovwid0 { get; set; }
        public object[] ovwty0 { get; set; }
        public object[] pDSaD0 { get; set; }
        public int[] pat2 { get; set; }
        public int[] patm { get; set; }
        public int[] pcbd { get; set; }
        public int[] pcl { get; set; }
        public object[] pden0 { get; set; }
        public int[] pedr { get; set; }
        public int[] pekr { get; set; }
        public int[] pglr { get; set; }
        public object[] pl2an0 { get; set; }
        public int[] plkr { get; set; }
        public object[] plvrl0 { get; set; }
        public int[] plyl { get; set; }
        public int[] ppk { get; set; }
        public int[] pptint { get; set; }
        public object[] pribt0 { get; set; }
        public object[] prmg0 { get; set; }
        public int[] ptint { get; set; }
        public int[] rcst1q { get; set; }
        public int[] rcst2q { get; set; }
        public int[] rcst3q { get; set; }
        public int[] rcst4q { get; set; }
        public object[] rdel0 { get; set; }
        public object[] remiveh0 { get; set; }
        public int[] repcr { get; set; }
        public object[] rgnd0 { get; set; }
        public object[] rgnm0 { get; set; }
        public object[] rgnr0 { get; set; }
        public int[] rilmvbs { get; set; }
        public object[] rlbs00 { get; set; }
        public object[] rlbs01 { get; set; }
        public object[] rlbs02 { get; set; }
        public object[] rlbs03 { get; set; }
        public string[] rlnm0 { get; set; }
        public string[] rlnm1 { get; set; }
        public string[] rlnm2 { get; set; }
        public string[] rlnm3 { get; set; }
        public object[] rloft0 { get; set; }
        public object[] rloftv0 { get; set; }
        public object[] rltiA0 { get; set; }
        public object[] rltiB0 { get; set; }
        public object[] rltiC0 { get; set; }
        public object[] rltiD0 { get; set; }
        public object[] rnrbs0 { get; set; }
        public object[] roapa0 { get; set; }
        public object[] rocok0 { get; set; }
        public object[] rodp0 { get; set; }
        public object[] rodpt0 { get; set; }
        public object[] rolsw0 { get; set; }
        public object[] rorcp0 { get; set; }
        public object[] rotes0 { get; set; }
        public int[] rpgbs1 { get; set; }
        public int[] rpgbs2 { get; set; }
        public int[] rpgbs3 { get; set; }
        public object[] rsiv0 { get; set; }
        public int[] sdobs { get; set; }
        public float[] shd { get; set; }
        public object[] shdtxt0 { get; set; }
        public int[] sia0 { get; set; }
        public int[] siat0 { get; set; }
        public float[] sim0 { get; set; }
        public int[] sinv { get; set; }
        public int[] sinv2 { get; set; }
        public int[] sinv3 { get; set; }
        public Sm[] sms { get; set; }
        public int[] spar { get; set; }
        public int[] spit { get; set; }
        public string[] spsy1 { get; set; }
        public string[] spsy2 { get; set; }
        public int[] spwia { get; set; }
        public object[] sthpp0 { get; set; }
        public int[] stiam0 { get; set; }
        public int[] stiamt0 { get; set; }
        public Stpos[] stpos { get; set; }
        public object[] sudtm0 { get; set; }
        public int[] swmbs { get; set; }
        public object[] swtod0 { get; set; }
        public object[] swtok0 { get; set; }
        public object[] tak0 { get; set; }
        public int[] tblpv1 { get; set; }
        public int[] tblpv2 { get; set; }
        public int[] tblpv3 { get; set; }
        public int[] tblpv4 { get; set; }
        public Tcp[] tcp { get; set; }
        public Tcr[] tcr { get; set; }
        public int[] teamrvbh { get; set; }
        public int[] teamrvc { get; set; }
        public int[] teamrvcs { get; set; }
        public int[] teamrvp { get; set; }
        public int[] teamv { get; set; }
        public int[] tehlh { get; set; }
        public int[] tehrn { get; set; }
        public int[] tenms { get; set; }
        public int[] thlb1 { get; set; }
        public int[] thlb2 { get; set; }
        public int[] thlb3 { get; set; }
        public int[] thlb4 { get; set; }
        public int[] thudv1 { get; set; }
        public int[] thudv2 { get; set; }
        public int[] thudv3 { get; set; }
        public int[] thudv4 { get; set; }
        public int[] time { get; set; }
        public int[] tmbt2 { get; set; }
        public int[] tmbt3 { get; set; }
        public int[] tmbt4 { get; set; }
        public int[] tmbts { get; set; }
        public int[] tmfrcwp { get; set; }
        public object[] tms0 { get; set; }
        public object[] tmt0 { get; set; }
        public int[] tmwntd { get; set; }
        public object[] todh0 { get; set; }
        public object[] todm0 { get; set; }
        public object[] tods0 { get; set; }
        public object[] todsh0 { get; set; }
        public object[] traf0 { get; set; }
        public object[] tsc0 { get; set; }
        public object[] tscm0 { get; set; }
        public int[] tstop { get; set; }
        public int[] tstrt { get; set; }
        public object[] ttlc0 { get; set; }
        public int[] tvBomb { get; set; }
        public int[] tvmCMO1 { get; set; }
        public int[] tvmCMO2 { get; set; }
        public int[] tvma { get; set; }
        public int[] tvmac { get; set; }
        public int[] tvmet { get; set; }
        public int[] tvmspoil { get; set; }
        public int[] tvmt { get; set; }
        public object[] twpptd0 { get; set; }
        public object[] txt0 { get; set; }
        public object[] txt10 { get; set; }
        public object[] txt20 { get; set; }
        public object[] txt30 { get; set; }
        public object[] txt40 { get; set; }
        public object[] txt50 { get; set; }
        public int[] uacp10 { get; set; }
        public int[] uacp20 { get; set; }
        public Vareapos[] vareapos { get; set; }
        public int[] vdohu { get; set; }
        public int[] vdoibs { get; set; }
        public object[] vdor0 { get; set; }
        public int[] vedr { get; set; }
        public object[] vehdmri0 { get; set; }
        public object[] vehdmro0 { get; set; }
        public int[] vehrsp { get; set; }
        public int[] vhkr { get; set; }
        public object[] vhm0 { get; set; }
        public object[] vrach0 { get; set; }
        public object[] vrach20 { get; set; }
        public object[] vss0 { get; set; }
        public object[] wchg0 { get; set; }
        public object[] wdly0 { get; set; }
        public object[] wfrc0 { get; set; }
        public int[] wla { get; set; }
        public int[] wla2 { get; set; }
        public object[] wldbs0 { get; set; }
        public int[] woabs { get; set; }
        public int[] wodia { get; set; }
        public object[] wprs0 { get; set; }
        public object[] wwm0 { get; set; }
    }

    public class Epos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Sm
    {
        public int delay { get; set; }
        public int ptsreq { get; set; }
        public int rule { get; set; }
        public int sndall { get; set; }
        public int team { get; set; }
        public int time { get; set; }
        public string txt0 { get; set; }
        public string txt1 { get; set; }
    }

    public class Stpos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tcp
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tcr
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vareapos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ene
    {
        public object[] accu { get; set; }
        public object[] ar0 { get; set; }
        public object[] ar1 { get; set; }
        public object[] ar2 { get; set; }
        public object[] ar3 { get; set; }
        public object[] as0 { get; set; }
        public object[] as1 { get; set; }
        public object[] as2 { get; set; }
        public object[] as3 { get; set; }
        public object[] bit0 { get; set; }
        public object[] bit1 { get; set; }
        public object[] bit2 { get; set; }
        public object[] bit3 { get; set; }
        public object[] cmsty { get; set; }
        public object[] flee { get; set; }
        public object[] foll { get; set; }
        public object[] frr { get; set; }
        public object[] gg0 { get; set; }
        public object[] gg1 { get; set; }
        public object[] gg2 { get; set; }
        public object[] gg3 { get; set; }
        public object[] gun { get; set; }
        public object[] head { get; set; }
        public object[] head0 { get; set; }
        public object[] head1 { get; set; }
        public object[] head2 { get; set; }
        public object[] head3 { get; set; }
        public object[] hlt { get; set; }
        public object[] iaim { get; set; }
        public object[] iaimr { get; set; }
        public object[] iaimt { get; set; }
        public object[] lgacc { get; set; }
        public object[] lghlt { get; set; }
        public object[] loc { get; set; }
        public object[] loc0 { get; set; }
        public object[] loc1 { get; set; }
        public object[] loc2 { get; set; }
        public object[] loc3 { get; set; }
        public object[] model { get; set; }
        public int no { get; set; }
        public int no0 { get; set; }
        public int no1 { get; set; }
        public int no2 { get; set; }
        public int no3 { get; set; }
        public object[] p2sh { get; set; }
        public object[] p2sp { get; set; }
        public object[] pada { get; set; }
        public int pal { get; set; }
        public object[] paot { get; set; }
        public object[] pbs10 { get; set; }
        public object[] pbs11 { get; set; }
        public object[] pbs12 { get; set; }
        public object[] pbs3 { get; set; }
        public object[] pbs4 { get; set; }
        public object[] pbs5 { get; set; }
        public object[] pbs6 { get; set; }
        public object[] pbs7 { get; set; }
        public object[] pbs8 { get; set; }
        public object[] pbs9 { get; set; }
        public object[] pbstwo { get; set; }
        public object[] pedbs { get; set; }
        public object[] pfh { get; set; }
        public object[] pfrmr { get; set; }
        public object[] pgtho { get; set; }
        public object[] pgthoh { get; set; }
        public object[] pmfhat { get; set; }
        public object[] prorbs { get; set; }
        public object[] psnei { get; set; }
        public object[] psnt { get; set; }
        public object[] qu0 { get; set; }
        public object[] qu1 { get; set; }
        public object[] qu2 { get; set; }
        public object[] qu3 { get; set; }
        public object[] rng { get; set; }
        public object[] rsp { get; set; }
        public object[] sanim { get; set; }
        public object[] sara { get; set; }
        public object[] saru { get; set; }
        public object[] sat { get; set; }
        public object[] satt { get; set; }
        public object[] skill { get; set; }
        public int spcap { get; set; }
        public object[] tars0 { get; set; }
        public object[] tars1 { get; set; }
        public object[] tars2 { get; set; }
        public object[] tars3 { get; set; }
        public int time { get; set; }
        public object[] tspr0 { get; set; }
        public object[] tspr1 { get; set; }
        public object[] tspr2 { get; set; }
        public object[] tspr3 { get; set; }
        public object[] ttm0 { get; set; }
        public object[] ttm1 { get; set; }
        public object[] ttm2 { get; set; }
        public object[] ttm3 { get; set; }
        public object[] ty0 { get; set; }
        public object[] ty1 { get; set; }
        public object[] ty2 { get; set; }
        public object[] ty3 { get; set; }
        public object[] veh { get; set; }
        public object[] veh0 { get; set; }
        public object[] veh1 { get; set; }
        public object[] veh2 { get; set; }
        public object[] veh3 { get; set; }
        public object[] vfre0 { get; set; }
        public object[] vfre1 { get; set; }
        public object[] vfre2 { get; set; }
        public object[] vfre3 { get; set; }
        public object[] vfrs0 { get; set; }
        public object[] vfrs1 { get; set; }
        public object[] vfrs2 { get; set; }
        public object[] vfrs3 { get; set; }
        public object[] wep { get; set; }
        public object[] whost { get; set; }
    }

    public class Fsp
    {
        public float[] head { get; set; }
        public Loc1[] loc { get; set; }
    }

    public class Loc1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Gen
    {
        public int _1cmrt0 { get; set; }
        public int _1cmrt1 { get; set; }
        public int _1cmrt2 { get; set; }
        public int _1cmrt3 { get; set; }
        public int _2cmrt0 { get; set; }
        public int _2cmrt1 { get; set; }
        public int _2cmrt2 { get; set; }
        public int _2cmrt3 { get; set; }
        public int _3cmrt0 { get; set; }
        public int _3cmrt1 { get; set; }
        public int _3cmrt2 { get; set; }
        public int _3cmrt3 { get; set; }
        public int _4cmrt0 { get; set; }
        public int _4cmrt1 { get; set; }
        public int _4cmrt2 { get; set; }
        public int _4cmrt3 { get; set; }
        public int GMsttm { get; set; }
        public int GMswrt { get; set; }
        public int GMt1r1 { get; set; }
        public int GMt1r2 { get; set; }
        public int GMt2r1 { get; set; }
        public int GMt2r2 { get; set; }
        public int adverm { get; set; }
        public float aghd { get; set; }
        public int agt { get; set; }
        public int alfutvs { get; set; }
        public bool alrtLocal { get; set; }

        [JsonProperty("alttype")]
        public int AlternativeType { get; set; }
        public int anf1BS0 { get; set; }
        public int anf1BS1 { get; set; }
        public int anf1BS2 { get; set; }
        public int anf1BS3 { get; set; }
        public int anf2BS0 { get; set; }
        public int anf2BS1 { get; set; }
        public int anf2BS2 { get; set; }
        public int anf2BS3 { get; set; }
        public int anf3BS0 { get; set; }
        public int anf3BS1 { get; set; }
        public int anf3BS2 { get; set; }
        public int anf3BS3 { get; set; }
        public int anf4BS0 { get; set; }
        public int anf4BS1 { get; set; }
        public int anf4BS2 { get; set; }
        public int anf4BS3 { get; set; }
        public int anfMBS0 { get; set; }
        public int anfMBS1 { get; set; }
        public int anfMBS2 { get; set; }
        public int anfMBS3 { get; set; }
        public Apart apart { get; set; }
        public int apwbs { get; set; }
        public int apwfr0 { get; set; }
        public int apwfr1 { get; set; }
        public int apwfr2 { get; set; }
        public int apwfr3 { get; set; }
        public int apwlr0 { get; set; }
        public int apwlr1 { get; set; }
        public int apwlr2 { get; set; }
        public int apwlr3 { get; set; }
        public Area area { get; set; }
        public int arnBnA { get; set; }
        public int arnBnB { get; set; }
        public int arnBnC { get; set; }
        public int arnBnD { get; set; }
        public int arnCrA { get; set; }
        public int arnCrB { get; set; }
        public int arnCrC { get; set; }
        public int arnCrD { get; set; }
        public int arnLi { get; set; }
        public int arnRnL { get; set; }
        public int arnTh { get; set; }
        public int arnTy { get; set; }
        public int arnVMN { get; set; }
        public int atmdm { get; set; }
        public Atscmp atscmp { get; set; }
        public Atscmr atscmr { get; set; }
        public float atsfov { get; set; }
        public float atshed { get; set; }
        public Atspos atspos { get; set; }
        public int atsveh { get; set; }
        public int ausc { get; set; }
        public int avss0 { get; set; }
        public int avss1 { get; set; }
        public int avss2 { get; set; }
        public int avss3 { get; set; }
        public int avss4 { get; set; }
        public int avss5 { get; set; }
        public int awpsobm { get; set; }
        public int awtrc { get; set; }
        public int awtt0 { get; set; }
        public int awtt1 { get; set; }
        public int awtt10 { get; set; }
        public int awtt11 { get; set; }
        public int awtt12 { get; set; }
        public int awtt13 { get; set; }
        public int awtt14 { get; set; }
        public int awtt15 { get; set; }
        public int awtt16 { get; set; }
        public int awtt17 { get; set; }
        public int awtt18 { get; set; }
        public int awtt19 { get; set; }
        public int awtt2 { get; set; }
        public int awtt20 { get; set; }
        public int awtt21 { get; set; }
        public int awtt22 { get; set; }
        public int awtt23 { get; set; }
        public int awtt24 { get; set; }
        public int awtt25 { get; set; }
        public int awtt26 { get; set; }
        public int awtt27 { get; set; }
        public int awtt28 { get; set; }
        public int awtt29 { get; set; }
        public int awtt3 { get; set; }
        public int awtt30 { get; set; }
        public int awtt31 { get; set; }
        public int awtt4 { get; set; }
        public int awtt5 { get; set; }
        public int awtt6 { get; set; }
        public int awtt7 { get; set; }
        public int awtt8 { get; set; }
        public int awtt9 { get; set; }
        public float bevhdd { get; set; }
        public float bevhtd { get; set; }
        public string blmpmsg { get; set; }
        public int bmbbp { get; set; }
        public float bmbdi { get; set; }
        public int bmber { get; set; }

        [JsonProperty("bmbet")]
        public int MaximumBetAmount { get; set; }
        public float bmbio { get; set; }
        public int bmbsi { get; set; }

        [JsonProperty("cam")]
        public Cam LobbyCam { get; set; }

        [JsonProperty("camf")]
        public Camf FinishedCamLocation { get; set; }

        [JsonProperty("camfr")]
        public Camfr FinishedCamRotation { get; set; }
        public float camfv { get; set; }

        [JsonProperty("camh")]
        public float LobbyCamHeading { get; set; }
        public Camo camo { get; set; }
        public float camp { get; set; }
        public Camro camro { get; set; }
        public float cdrt { get; set; }
        public int _char { get; set; }
        public int charcon { get; set; }
        public bool chksfx { get; set; }
        public int clbscr { get; set; }
        public int clrovr0 { get; set; }
        public int clrovr1 { get; set; }
        public int clrovr2 { get; set; }
        public int clrovr3 { get; set; }
        public int cmpts { get; set; }
        public int cmxdctl { get; set; }
        public int cmxdftms { get; set; }
        public int cmxmctl { get; set; }
        public int cmxtliv { get; set; }
        public int cncmbs { get; set; }
        public float conbons { get; set; }
        public int confont { get; set; }
        public int confot { get; set; }
        public int consd { get; set; }
        public float conspd { get; set; }
        public int copteam { get; set; }
        public int cordmbs { get; set; }
        public float cph0i0s0 { get; set; }
        public float cph0i0s1 { get; set; }
        public float cph0i0s2 { get; set; }
        public float cph0i0s3 { get; set; }
        public float cph0i1s0 { get; set; }
        public float cph0i1s1 { get; set; }
        public float cph0i1s2 { get; set; }
        public float cph0i1s3 { get; set; }
        public float cph0i2s0 { get; set; }
        public float cph0i2s1 { get; set; }
        public float cph0i2s2 { get; set; }
        public float cph0i2s3 { get; set; }
        public float cph0i3s0 { get; set; }
        public float cph0i3s1 { get; set; }
        public float cph0i3s2 { get; set; }
        public float cph0i3s3 { get; set; }
        public float cph0i4s0 { get; set; }
        public float cph0i4s1 { get; set; }
        public float cph0i4s2 { get; set; }
        public float cph0i4s3 { get; set; }
        public float cph1i0s0 { get; set; }
        public float cph1i0s1 { get; set; }
        public float cph1i0s2 { get; set; }
        public float cph1i0s3 { get; set; }
        public float cph1i1s0 { get; set; }
        public float cph1i1s1 { get; set; }
        public float cph1i1s2 { get; set; }
        public float cph1i1s3 { get; set; }
        public float cph1i2s0 { get; set; }
        public float cph1i2s1 { get; set; }
        public float cph1i2s2 { get; set; }
        public float cph1i2s3 { get; set; }
        public float cph1i3s0 { get; set; }
        public float cph1i3s1 { get; set; }
        public float cph1i3s2 { get; set; }
        public float cph1i3s3 { get; set; }
        public float cph1i4s0 { get; set; }
        public float cph1i4s1 { get; set; }
        public float cph1i4s2 { get; set; }
        public float cph1i4s3 { get; set; }
        public float cph2i0s0 { get; set; }
        public float cph2i0s1 { get; set; }
        public float cph2i0s2 { get; set; }
        public float cph2i0s3 { get; set; }
        public float cph2i1s0 { get; set; }
        public float cph2i1s1 { get; set; }
        public float cph2i1s2 { get; set; }
        public float cph2i1s3 { get; set; }
        public float cph2i2s0 { get; set; }
        public float cph2i2s1 { get; set; }
        public float cph2i2s2 { get; set; }
        public float cph2i2s3 { get; set; }
        public float cph2i3s0 { get; set; }
        public float cph2i3s1 { get; set; }
        public float cph2i3s2 { get; set; }
        public float cph2i3s3 { get; set; }
        public float cph2i4s0 { get; set; }
        public float cph2i4s1 { get; set; }
        public float cph2i4s2 { get; set; }
        public float cph2i4s3 { get; set; }
        public float cph3i0s0 { get; set; }
        public float cph3i0s1 { get; set; }
        public float cph3i0s2 { get; set; }
        public float cph3i0s3 { get; set; }
        public float cph3i1s0 { get; set; }
        public float cph3i1s1 { get; set; }
        public float cph3i1s2 { get; set; }
        public float cph3i1s3 { get; set; }
        public float cph3i2s0 { get; set; }
        public float cph3i2s1 { get; set; }
        public float cph3i2s2 { get; set; }
        public float cph3i2s3 { get; set; }
        public float cph3i3s0 { get; set; }
        public float cph3i3s1 { get; set; }
        public float cph3i3s2 { get; set; }
        public float cph3i3s3 { get; set; }
        public float cph3i4s0 { get; set; }
        public float cph3i4s1 { get; set; }
        public float cph3i4s2 { get; set; }
        public float cph3i4s3 { get; set; }
        public float cpohr { get; set; }
        public float cpopr { get; set; }
        public float cporv { get; set; }
        public float cposr { get; set; }
        public Cpv0i0s0 cpv0i0s0 { get; set; }
        public Cpv0i0s1 cpv0i0s1 { get; set; }
        public Cpv0i0s2 cpv0i0s2 { get; set; }
        public Cpv0i0s3 cpv0i0s3 { get; set; }
        public Cpv0i1s0 cpv0i1s0 { get; set; }
        public Cpv0i1s1 cpv0i1s1 { get; set; }
        public Cpv0i1s2 cpv0i1s2 { get; set; }
        public Cpv0i1s3 cpv0i1s3 { get; set; }
        public Cpv0i2s0 cpv0i2s0 { get; set; }
        public Cpv0i2s1 cpv0i2s1 { get; set; }
        public Cpv0i2s2 cpv0i2s2 { get; set; }
        public Cpv0i2s3 cpv0i2s3 { get; set; }
        public Cpv0i3s0 cpv0i3s0 { get; set; }
        public Cpv0i3s1 cpv0i3s1 { get; set; }
        public Cpv0i3s2 cpv0i3s2 { get; set; }
        public Cpv0i3s3 cpv0i3s3 { get; set; }
        public Cpv0i4s0 cpv0i4s0 { get; set; }
        public Cpv0i4s1 cpv0i4s1 { get; set; }
        public Cpv0i4s2 cpv0i4s2 { get; set; }
        public Cpv0i4s3 cpv0i4s3 { get; set; }
        public Cpv1i0s0 cpv1i0s0 { get; set; }
        public Cpv1i0s1 cpv1i0s1 { get; set; }
        public Cpv1i0s2 cpv1i0s2 { get; set; }
        public Cpv1i0s3 cpv1i0s3 { get; set; }
        public Cpv1i1s0 cpv1i1s0 { get; set; }
        public Cpv1i1s1 cpv1i1s1 { get; set; }
        public Cpv1i1s2 cpv1i1s2 { get; set; }
        public Cpv1i1s3 cpv1i1s3 { get; set; }
        public Cpv1i2s0 cpv1i2s0 { get; set; }
        public Cpv1i2s1 cpv1i2s1 { get; set; }
        public Cpv1i2s2 cpv1i2s2 { get; set; }
        public Cpv1i2s3 cpv1i2s3 { get; set; }
        public Cpv1i3s0 cpv1i3s0 { get; set; }
        public Cpv1i3s1 cpv1i3s1 { get; set; }
        public Cpv1i3s2 cpv1i3s2 { get; set; }
        public Cpv1i3s3 cpv1i3s3 { get; set; }
        public Cpv1i4s0 cpv1i4s0 { get; set; }
        public Cpv1i4s1 cpv1i4s1 { get; set; }
        public Cpv1i4s2 cpv1i4s2 { get; set; }
        public Cpv1i4s3 cpv1i4s3 { get; set; }
        public Cpv2i0s0 cpv2i0s0 { get; set; }
        public Cpv2i0s1 cpv2i0s1 { get; set; }
        public Cpv2i0s2 cpv2i0s2 { get; set; }
        public Cpv2i0s3 cpv2i0s3 { get; set; }
        public Cpv2i1s0 cpv2i1s0 { get; set; }
        public Cpv2i1s1 cpv2i1s1 { get; set; }
        public Cpv2i1s2 cpv2i1s2 { get; set; }
        public Cpv2i1s3 cpv2i1s3 { get; set; }
        public Cpv2i2s0 cpv2i2s0 { get; set; }
        public Cpv2i2s1 cpv2i2s1 { get; set; }
        public Cpv2i2s2 cpv2i2s2 { get; set; }
        public Cpv2i2s3 cpv2i2s3 { get; set; }
        public Cpv2i3s0 cpv2i3s0 { get; set; }
        public Cpv2i3s1 cpv2i3s1 { get; set; }
        public Cpv2i3s2 cpv2i3s2 { get; set; }
        public Cpv2i3s3 cpv2i3s3 { get; set; }
        public Cpv2i4s0 cpv2i4s0 { get; set; }
        public Cpv2i4s1 cpv2i4s1 { get; set; }
        public Cpv2i4s2 cpv2i4s2 { get; set; }
        public Cpv2i4s3 cpv2i4s3 { get; set; }
        public Cpv3i0s0 cpv3i0s0 { get; set; }
        public Cpv3i0s1 cpv3i0s1 { get; set; }
        public Cpv3i0s2 cpv3i0s2 { get; set; }
        public Cpv3i0s3 cpv3i0s3 { get; set; }
        public Cpv3i1s0 cpv3i1s0 { get; set; }
        public Cpv3i1s1 cpv3i1s1 { get; set; }
        public Cpv3i1s2 cpv3i1s2 { get; set; }
        public Cpv3i1s3 cpv3i1s3 { get; set; }
        public Cpv3i2s0 cpv3i2s0 { get; set; }
        public Cpv3i2s1 cpv3i2s1 { get; set; }
        public Cpv3i2s2 cpv3i2s2 { get; set; }
        public Cpv3i2s3 cpv3i2s3 { get; set; }
        public Cpv3i3s0 cpv3i3s0 { get; set; }
        public Cpv3i3s1 cpv3i3s1 { get; set; }
        public Cpv3i3s2 cpv3i3s2 { get; set; }
        public Cpv3i3s3 cpv3i3s3 { get; set; }
        public Cpv3i4s0 cpv3i4s0 { get; set; }
        public Cpv3i4s1 cpv3i4s1 { get; set; }
        public Cpv3i4s2 cpv3i4s2 { get; set; }
        public Cpv3i4s3 cpv3i4s3 { get; set; }
        public int crlaa { get; set; }
        public int crttn { get; set; }
        public int cshr { get; set; }
        public int csstd { get; set; }
        public string csstl { get; set; }
        public string csstl2 { get; set; }
        public string csstl3 { get; set; }
        public float csts { get; set; }
        public string csttl { get; set; }
        public string csttl2 { get; set; }
        public string csttl3 { get; set; }
        public string ctmrs { get; set; }
        public int ctsc { get; set; }
        public int cwspre { get; set; }
        public int cwspre1 { get; set; }
        public int cwspre2 { get; set; }
        public int cwspre3 { get; set; }
        public string cwstr { get; set; }
        public string cwstr1 { get; set; }
        public string cwstr2 { get; set; }
        public string cwstr3 { get; set; }
        public string cwtit { get; set; }
        public string cwtit1 { get; set; }
        public string cwtit2 { get; set; }
        public string cwtit3 { get; set; }

        [JsonProperty("dec")]
        public string[] Descriptions { get; set; }
        public int dfofit0 { get; set; }
        public int dfofit1 { get; set; }
        public int dfofit2 { get; set; }
        public int dfofit3 { get; set; }
        public int dfstyl0 { get; set; }
        public int dfstyl1 { get; set; }
        public int dfstyl2 { get; set; }
        public int dfstyl3 { get; set; }
        public int disar { get; set; }
        public string dmHT00 { get; set; }
        public string dmHT01 { get; set; }
        public string dmHT02 { get; set; }
        public string dmHT03 { get; set; }
        public string dmHT10 { get; set; }
        public string dmHT11 { get; set; }
        public string dmHT12 { get; set; }
        public string dmHT13 { get; set; }
        public string dmHT20 { get; set; }
        public string dmHT21 { get; set; }
        public string dmHT22 { get; set; }
        public string dmHT23 { get; set; }
        public string dmHT30 { get; set; }
        public string dmHT31 { get; set; }
        public string dmHT32 { get; set; }
        public string dmHT33 { get; set; }
        public string dmHT40 { get; set; }
        public string dmHT41 { get; set; }
        public string dmHT42 { get; set; }
        public string dmHT43 { get; set; }
        public int dmHTD0 { get; set; }
        public int dmHTD1 { get; set; }
        public int dmHTD2 { get; set; }
        public int dmHTD3 { get; set; }
        public int dmHTD4 { get; set; }
        public string dmHTS0 { get; set; }
        public string dmHTS1 { get; set; }
        public string dmHTS2 { get; set; }
        public string dmHTS3 { get; set; }
        public string dmHTS4 { get; set; }
        public int dmaskg0 { get; set; }
        public int dmaskg1 { get; set; }
        public int dmaskg2 { get; set; }
        public int dmaskg3 { get; set; }
        public float dmbds { get; set; }
        public int dmvft0 { get; set; }
        public int dmvft1 { get; set; }
        public int dmvft10 { get; set; }
        public int dmvft11 { get; set; }
        public int dmvft12 { get; set; }
        public int dmvft13 { get; set; }
        public int dmvft14 { get; set; }
        public int dmvft15 { get; set; }
        public int dmvft16 { get; set; }
        public int dmvft17 { get; set; }
        public int dmvft18 { get; set; }
        public int dmvft19 { get; set; }
        public int dmvft2 { get; set; }
        public int dmvft20 { get; set; }
        public int dmvft21 { get; set; }
        public int dmvft22 { get; set; }
        public int dmvft23 { get; set; }
        public int dmvft24 { get; set; }
        public int dmvft25 { get; set; }
        public int dmvft3 { get; set; }
        public int dmvft4 { get; set; }
        public int dmvft5 { get; set; }
        public int dmvft6 { get; set; }
        public int dmvft7 { get; set; }
        public int dmvft8 { get; set; }
        public int dmvft9 { get; set; }
        public int dspteam { get; set; }
        public int dtn { get; set; }
        public int ecsbs { get; set; }
        public int ecsbs2 { get; set; }
        public Ecscp ecscp { get; set; }
        public float ecscr { get; set; }
        public Ecscs ecscs { get; set; }
        public int ecsrng { get; set; }
        public int endtype { get; set; }
        public float etim { get; set; }
        public float etimb { get; set; }
        public float evel { get; set; }
        public float evelb { get; set; }
        public int fixcam { get; set; }
        public float frtr0 { get; set; }
        public float frtr1 { get; set; }
        public float frtr2 { get; set; }
        public float frtr3 { get; set; }
        public Fsclr0 fsclr0 { get; set; }
        public Fsclr1 fsclr1 { get; set; }
        public Fsclr2 fsclr2 { get; set; }
        public Fsclr3 fsclr3 { get; set; }
        public Fsclr4 fsclr4 { get; set; }
        public Fsclr5 fsclr5 { get; set; }
        public Fsclr6 fsclr6 { get; set; }
        public Fsclr7 fsclr7 { get; set; }
        public Fsclr8 fsclr8 { get; set; }
        public Fsclr9 fsclr9 { get; set; }
        public Fsclv0 fsclv0 { get; set; }
        public Fsclv1 fsclv1 { get; set; }
        public Fsclv2 fsclv2 { get; set; }
        public Fsclv3 fsclv3 { get; set; }
        public Fsclv4 fsclv4 { get; set; }
        public Fsclv5 fsclv5 { get; set; }
        public Fsclv6 fsclv6 { get; set; }
        public Fsclv7 fsclv7 { get; set; }
        public Fsclv8 fsclv8 { get; set; }
        public Fsclv9 fsclv9 { get; set; }
        public int fvjfvc { get; set; }
        public int fvjfvd { get; set; }
        public int fvjhdt { get; set; }
        public int fvjhmd { get; set; }
        public int gear0 { get; set; }
        public int gear1 { get; set; }
        public int gear2 { get; set; }
        public int gear3 { get; set; }
        public int geard0 { get; set; }
        public int geard1 { get; set; }
        public int geard2 { get; set; }
        public int geard3 { get; set; }
        public int gpmn { get; set; }
        public int hbhs { get; set; }
        public int hbht { get; set; }
        public int hbrbs { get; set; }
        public int hbrkt { get; set; }
        public int hbrpdt { get; set; }
        public int hbrph { get; set; }
        public int hbrtrl { get; set; }
        public int hbrtt { get; set; }
        public int hbrttm { get; set; }
        public int hbrvdt { get; set; }
        public int hecam { get; set; }
        public int hmmte { get; set; }
        public int hmmth { get; set; }
        public int hmmts { get; set; }
        public int hmmtt { get; set; }
        public int hpdt1 { get; set; }
        public int hpdt2 { get; set; }
        public int hpped { get; set; }
        public int hpped2 { get; set; }
        public int hpped3 { get; set; }
        public int hpped4 { get; set; }
        public int hpped5 { get; set; }
        public int hpped6 { get; set; }
        public int hptfb { get; set; }
        public int hrdnt { get; set; }
        public int hstat { get; set; }
        public int igls { get; set; }
        public int iltt00 { get; set; }
        public int iltt01 { get; set; }
        public int iltt02 { get; set; }
        public int iltt03 { get; set; }
        public int iltt10 { get; set; }
        public int iltt11 { get; set; }
        public int iltt12 { get; set; }
        public int iltt13 { get; set; }
        public int iltt20 { get; set; }
        public int iltt21 { get; set; }
        public int iltt22 { get; set; }
        public int iltt23 { get; set; }
        public int iltt30 { get; set; }
        public int iltt31 { get; set; }
        public int iltt32 { get; set; }
        public int iltt33 { get; set; }
        public int intop { get; set; }
        public int intop2 { get; set; }
        public int inumbnc { get; set; }
        public int iopcd { get; set; }
        public int iplop { get; set; }
        public int iplyli { get; set; }
        public int itsms { get; set; }

        [JsonProperty("ivm")]
        public int DefaultVehicleHash { get; set; }
        public int kspr0 { get; set; }
        public int kspr1 { get; set; }
        public int kspr2 { get; set; }
        public int kspr3 { get; set; }
        public int kspt0 { get; set; }
        public int kspt1 { get; set; }
        public int kspt2 { get; set; }
        public int kspt3 { get; set; }
        public int ldpucd { get; set; }
        public int ltm { get; set; }
        public int mask10 { get; set; }
        public int mask11 { get; set; }
        public int mask12 { get; set; }
        public int mask13 { get; set; }
        public float mdmgm { get; set; }
        public int menubs { get; set; }
        public int menubs10 { get; set; }
        public int menubs11 { get; set; }
        public int menubs12 { get; set; }
        public int menubs13 { get; set; }
        public int menubs14 { get; set; }
        public int menubs15 { get; set; }
        public int menubs16 { get; set; }
        public int menubs17 { get; set; }
        public int menubs18 { get; set; }
        public int menubs19 { get; set; }
        public int menubs2 { get; set; }
        public int menubs20 { get; set; }
        public int menubs21 { get; set; }
        public int menubs22 { get; set; }
        public int menubs23 { get; set; }
        public int menubs3 { get; set; }
        public int menubs4 { get; set; }
        public int menubs5 { get; set; }
        public int menubs6 { get; set; }
        public int menubs7 { get; set; }
        public int menubs8 { get; set; }
        public int menubs9 { get; set; }
        public int mght { get; set; }
        public int mgrk { get; set; }
        public int min { get; set; }
        public int minNu { get; set; }
        public int mjtr { get; set; }
        public int mocb1 { get; set; }
        public int mocb2 { get; set; }
        public int mocb3 { get; set; }
        public int mocbs { get; set; }
        public int moccc { get; set; }
        public int mrd { get; set; }
        public float mrtr0 { get; set; }
        public float mrtr1 { get; set; }
        public float mrtr2 { get; set; }
        public float mrtr3 { get; set; }
        public int mtnum { get; set; }
        public int musx { get; set; }
        public int mxlap { get; set; }
        public int newausc { get; set; }
        public bool ngjob { get; set; }

        [JsonProperty("nm")]
        public string MissionName { get; set; }
        public int nqrc { get; set; }
        public string nrcid0 { get; set; }
        public string nrcid1 { get; set; }
        public int num { get; set; }
        public int numzr { get; set; }
        public int objsctt { get; set; }
        public int ofit10 { get; set; }
        public int ofit100 { get; set; }
        public int ofit101 { get; set; }
        public int ofit102 { get; set; }
        public int ofit103 { get; set; }
        public int ofit11 { get; set; }
        public int ofit110 { get; set; }
        public int ofit111 { get; set; }
        public int ofit112 { get; set; }
        public int ofit113 { get; set; }
        public int ofit12 { get; set; }
        public int ofit120 { get; set; }
        public int ofit121 { get; set; }
        public int ofit122 { get; set; }
        public int ofit123 { get; set; }
        public int ofit13 { get; set; }
        public int ofit130 { get; set; }
        public int ofit131 { get; set; }
        public int ofit132 { get; set; }
        public int ofit133 { get; set; }
        public int ofit20 { get; set; }
        public int ofit21 { get; set; }
        public int ofit22 { get; set; }
        public int ofit23 { get; set; }
        public int ofit30 { get; set; }
        public int ofit31 { get; set; }
        public int ofit32 { get; set; }
        public int ofit33 { get; set; }
        public int ofit40 { get; set; }
        public int ofit41 { get; set; }
        public int ofit42 { get; set; }
        public int ofit43 { get; set; }
        public int ofit50 { get; set; }
        public int ofit51 { get; set; }
        public int ofit52 { get; set; }
        public int ofit53 { get; set; }
        public int ofit60 { get; set; }
        public int ofit61 { get; set; }
        public int ofit62 { get; set; }
        public int ofit63 { get; set; }
        public int ofit70 { get; set; }
        public int ofit71 { get; set; }
        public int ofit72 { get; set; }
        public int ofit73 { get; set; }
        public int ofit80 { get; set; }
        public int ofit81 { get; set; }
        public int ofit82 { get; set; }
        public int ofit83 { get; set; }
        public int ofit90 { get; set; }
        public int ofit91 { get; set; }
        public int ofit92 { get; set; }
        public int ofit93 { get; set; }
        public int ofovr0 { get; set; }
        public int ofovr1 { get; set; }
        public int ofovr2 { get; set; }
        public int ofovr3 { get; set; }
        public int ofs10 { get; set; }
        public int ofs11 { get; set; }
        public int ofs12 { get; set; }
        public int ofs13 { get; set; }
        public int ofs20 { get; set; }
        public int ofs21 { get; set; }
        public int ofs22 { get; set; }
        public int ofs23 { get; set; }
        public int optbs { get; set; }
        public int otrds { get; set; }
        public int otrpc { get; set; }
        public int otrsc { get; set; }
        public int otsdr { get; set; }
        public int ovrpc { get; set; }

        [JsonProperty("ownerid")]
        public string SocialClubMapOwnerId { get; set; }

        [JsonProperty("photo")]
        public bool HasPhoto { get; set; }

        [JsonProperty("phpo")]
        public Phpo PhotoPosition { get; set; }
        public Pmpoi0 pmpoi0 { get; set; }
        public Pmpoi1 pmpoi1 { get; set; }
        public Pmpoi2 pmpoi2 { get; set; }
        public Pmpoi3 pmpoi3 { get; set; }
        public Pmpos0 pmpos0 { get; set; }
        public Pmpos1 pmpos1 { get; set; }
        public Pmpos2 pmpos2 { get; set; }
        public Pmpos3 pmpos3 { get; set; }
        public float pmrad0 { get; set; }
        public float pmrad1 { get; set; }
        public float pmrad2 { get; set; }
        public float pmrad3 { get; set; }
        public int pmscid0 { get; set; }
        public int pmscid1 { get; set; }
        public int pmscid2 { get; set; }
        public int pmscid3 { get; set; }
        public string pnid0 { get; set; }
        public string pnid1 { get; set; }
        public string pnid10 { get; set; }
        public string pnid11 { get; set; }
        public string pnid12 { get; set; }
        public string pnid13 { get; set; }
        public string pnid14 { get; set; }
        public string pnid15 { get; set; }
        public string pnid16 { get; set; }
        public string pnid17 { get; set; }
        public string pnid2 { get; set; }
        public string pnid3 { get; set; }
        public string pnid4 { get; set; }
        public string pnid5 { get; set; }
        public string pnid6 { get; set; }
        public string pnid7 { get; set; }
        public string pnid8 { get; set; }
        public string pnid9 { get; set; }
        public int pnlv0 { get; set; }
        public int pnlv1 { get; set; }
        public int pnlv10 { get; set; }
        public int pnlv11 { get; set; }
        public int pnlv12 { get; set; }
        public int pnlv13 { get; set; }
        public int pnlv14 { get; set; }
        public int pnlv15 { get; set; }
        public int pnlv16 { get; set; }
        public int pnlv17 { get; set; }
        public int pnlv2 { get; set; }
        public int pnlv3 { get; set; }
        public int pnlv4 { get; set; }
        public int pnlv5 { get; set; }
        public int pnlv6 { get; set; }
        public int pnlv7 { get; set; }
        public int pnlv8 { get; set; }
        public int pnlv9 { get; set; }
        public int pnvr0 { get; set; }
        public int pnvr1 { get; set; }
        public int pnvr10 { get; set; }
        public int pnvr11 { get; set; }
        public int pnvr12 { get; set; }
        public int pnvr13 { get; set; }
        public int pnvr14 { get; set; }
        public int pnvr15 { get; set; }
        public int pnvr16 { get; set; }
        public int pnvr17 { get; set; }
        public int pnvr2 { get; set; }
        public int pnvr3 { get; set; }
        public int pnvr4 { get; set; }
        public int pnvr5 { get; set; }
        public int pnvr6 { get; set; }
        public int pnvr7 { get; set; }
        public int pnvr8 { get; set; }
        public int pnvr9 { get; set; }
        public int pptl { get; set; }
        public int propno { get; set; }
        public int prpccd { get; set; }
        public float ptbDrg { get; set; }
        public int ptbNBL { get; set; }
        public int ptlem { get; set; }
        public int ptltl { get; set; }
        public string pttl { get; set; }
        public int qran0 { get; set; }
        public int qran1 { get; set; }
        public int qran2 { get; set; }
        public int qran3 { get; set; }
        public float rad { get; set; }
        public int rank { get; set; }
        public int ratc0 { get; set; }
        public int ratc1 { get; set; }
        public int ratc2 { get; set; }
        public int ratc3 { get; set; }
        public int ratc4 { get; set; }
        public int ratc5 { get; set; }
        public int ratc6 { get; set; }
        public int ratc7 { get; set; }
        public int ratc8 { get; set; }
        public int ratc9 { get; set; }
        public float ratcm { get; set; }
        public int rcvs { get; set; }
        public int ricb { get; set; }
        public int rlopt { get; set; }
        public int rmlo { get; set; }
        public Rmspcc0 rmspcc0 { get; set; }
        public Rmspcc1 rmspcc1 { get; set; }
        public Rmspcc2 rmspcc2 { get; set; }
        public Rmspcc3 rmspcc3 { get; set; }
        public Rmspcc4 rmspcc4 { get; set; }
        public float rmspch0 { get; set; }
        public float rmspch1 { get; set; }
        public float rmspch2 { get; set; }
        public float rmspch3 { get; set; }
        public float rmspch4 { get; set; }
        public Rmspco0 rmspco0 { get; set; }
        public Rmspco1 rmspco1 { get; set; }
        public Rmspco2 rmspco2 { get; set; }
        public Rmspco3 rmspco3 { get; set; }
        public Rmspco4 rmspco4 { get; set; }
        public float rmspcr0 { get; set; }
        public float rmspcr1 { get; set; }
        public float rmspcr2 { get; set; }
        public float rmspcr3 { get; set; }
        public float rmspcr4 { get; set; }
        public int rtveft0 { get; set; }
        public int rtveft1 { get; set; }
        public int rtveft2 { get; set; }
        public int rtveft3 { get; set; }
        public float rzacc0 { get; set; }
        public float rzacc1 { get; set; }
        public float rzacc10 { get; set; }
        public float rzacc11 { get; set; }
        public float rzacc12 { get; set; }
        public float rzacc13 { get; set; }
        public float rzacc14 { get; set; }
        public float rzacc15 { get; set; }
        public float rzacc16 { get; set; }
        public float rzacc17 { get; set; }
        public float rzacc18 { get; set; }
        public float rzacc19 { get; set; }
        public float rzacc2 { get; set; }
        public float rzacc3 { get; set; }
        public float rzacc4 { get; set; }
        public float rzacc5 { get; set; }
        public float rzacc6 { get; set; }
        public float rzacc7 { get; set; }
        public float rzacc8 { get; set; }
        public float rzacc9 { get; set; }
        public int rzcav0 { get; set; }
        public int rzcav1 { get; set; }
        public int rzcav10 { get; set; }
        public int rzcav11 { get; set; }
        public int rzcav12 { get; set; }
        public int rzcav13 { get; set; }
        public int rzcav14 { get; set; }
        public int rzcav15 { get; set; }
        public int rzcav16 { get; set; }
        public int rzcav17 { get; set; }
        public int rzcav18 { get; set; }
        public int rzcav19 { get; set; }
        public int rzcav2 { get; set; }
        public int rzcav3 { get; set; }
        public int rzcav4 { get; set; }
        public int rzcav5 { get; set; }
        public int rzcav6 { get; set; }
        public int rzcav7 { get; set; }
        public int rzcav8 { get; set; }
        public int rzcav9 { get; set; }
        public int rzhmb { get; set; }
        public int rzobj0 { get; set; }
        public int rzobj1 { get; set; }
        public int rzobj10 { get; set; }
        public int rzobj11 { get; set; }
        public int rzobj12 { get; set; }
        public int rzobj13 { get; set; }
        public int rzobj14 { get; set; }
        public int rzobj15 { get; set; }
        public int rzobj16 { get; set; }
        public int rzobj17 { get; set; }
        public int rzobj18 { get; set; }
        public int rzobj19 { get; set; }
        public int rzobj2 { get; set; }
        public int rzobj3 { get; set; }
        public int rzobj4 { get; set; }
        public int rzobj5 { get; set; }
        public int rzobj6 { get; set; }
        public int rzobj7 { get; set; }
        public int rzobj8 { get; set; }
        public int rzobj9 { get; set; }
        public Rzpos0 rzpos0 { get; set; }
        public Rzpos1 rzpos1 { get; set; }
        public Rzpos10 rzpos10 { get; set; }
        public Rzpos11 rzpos11 { get; set; }
        public Rzpos12 rzpos12 { get; set; }
        public Rzpos13 rzpos13 { get; set; }
        public Rzpos14 rzpos14 { get; set; }
        public Rzpos15 rzpos15 { get; set; }
        public Rzpos16 rzpos16 { get; set; }
        public Rzpos17 rzpos17 { get; set; }
        public Rzpos18 rzpos18 { get; set; }
        public Rzpos19 rzpos19 { get; set; }
        public Rzpos2 rzpos2 { get; set; }
        public Rzpos3 rzpos3 { get; set; }
        public Rzpos4 rzpos4 { get; set; }
        public Rzpos5 rzpos5 { get; set; }
        public Rzpos6 rzpos6 { get; set; }
        public Rzpos7 rzpos7 { get; set; }
        public Rzpos8 rzpos8 { get; set; }
        public Rzpos9 rzpos9 { get; set; }
        public int rzzon0 { get; set; }
        public int rzzon1 { get; set; }
        public int rzzon10 { get; set; }
        public int rzzon11 { get; set; }
        public int rzzon12 { get; set; }
        public int rzzon13 { get; set; }
        public int rzzon14 { get; set; }
        public int rzzon15 { get; set; }
        public int rzzon16 { get; set; }
        public int rzzon17 { get; set; }
        public int rzzon18 { get; set; }
        public int rzzon19 { get; set; }
        public int rzzon2 { get; set; }
        public int rzzon3 { get; set; }
        public int rzzon4 { get; set; }
        public int rzzon5 { get; set; }
        public int rzzon6 { get; set; }
        public int rzzon7 { get; set; }
        public int rzzon8 { get; set; }
        public int rzzon9 { get; set; }
        public float sba { get; set; }
        public int sccd { get; set; }
        public int scd { get; set; }
        public float schf { get; set; }
        public int scmind { get; set; }
        public float scmnhf { get; set; }
        public float scmnhfs { get; set; }
        public float scmnvf { get; set; }
        public float scmnvfs { get; set; }
        public float scmsf { get; set; }
        public float scmxhf { get; set; }
        public float scmxvf { get; set; }
        public float scvf { get; set; }
        public float sddmg { get; set; }
        public float sddri { get; set; }
        public float sdidd { get; set; }
        public float sdmxp { get; set; }
        public float sdrsc { get; set; }
        public int sdrvm { get; set; }
        public int sdsr { get; set; }
        public float sdstp { get; set; }
        public float sdtick { get; set; }
        public int smoc { get; set; }
        public string specobjt0 { get; set; }
        public string specobjt1 { get; set; }
        public string specobjt2 { get; set; }
        public string specobjt3 { get; set; }
        public string specobjt4 { get; set; }
        public int sphft { get; set; }
        public int spwnptd { get; set; }
        public int srct { get; set; }
        public float ssder { get; set; }
        public Ssdsp ssdsp { get; set; }
        public float ssdsr { get; set; }
        public int ssdst { get; set; }
        public int ssdtg { get; set; }

        [JsonProperty("start")]
        public Start LobbyStartLocation { get; set; }
        public int subtype { get; set; }
        public int svmrcvbr { get; set; }
        public string szTag { get; set; }
        public int t00dv { get; set; }
        public int t00dvl { get; set; }
        public int t00rv0 { get; set; }
        public int t00rv01 { get; set; }
        public int t00rv02 { get; set; }
        public int t00rv1 { get; set; }
        public int t00rv10 { get; set; }
        public int t00rv101 { get; set; }
        public int t00rv102 { get; set; }
        public int t00rv11 { get; set; }
        public int t00rv111 { get; set; }
        public int t00rv112 { get; set; }
        public int t00rv12 { get; set; }
        public int t00rv121 { get; set; }
        public int t00rv122 { get; set; }
        public int t00rv13 { get; set; }
        public int t00rv131 { get; set; }
        public int t00rv132 { get; set; }
        public int t00rv14 { get; set; }
        public int t00rv141 { get; set; }
        public int t00rv142 { get; set; }
        public int t00rv15 { get; set; }
        public int t00rv151 { get; set; }
        public int t00rv152 { get; set; }
        public int t00rv16 { get; set; }
        public int t00rv161 { get; set; }
        public int t00rv162 { get; set; }
        public int t00rv17 { get; set; }
        public int t00rv171 { get; set; }
        public int t00rv172 { get; set; }
        public int t00rv18 { get; set; }
        public int t00rv181 { get; set; }
        public int t00rv182 { get; set; }
        public int t00rv19 { get; set; }
        public int t00rv191 { get; set; }
        public int t00rv192 { get; set; }
        public int t00rv2 { get; set; }
        public int t00rv20 { get; set; }
        public int t00rv201 { get; set; }
        public int t00rv202 { get; set; }
        public int t00rv21 { get; set; }
        public int t00rv211 { get; set; }
        public int t00rv212 { get; set; }
        public int t00rv22 { get; set; }
        public int t00rv221 { get; set; }
        public int t00rv222 { get; set; }
        public int t00rv23 { get; set; }
        public int t00rv231 { get; set; }
        public int t00rv232 { get; set; }
        public int t00rv24 { get; set; }
        public int t00rv241 { get; set; }
        public int t00rv242 { get; set; }
        public int t00rv25 { get; set; }
        public int t00rv251 { get; set; }
        public int t00rv252 { get; set; }
        public int t00rv3 { get; set; }
        public int t00rv31 { get; set; }
        public int t00rv32 { get; set; }
        public int t00rv4 { get; set; }
        public int t00rv41 { get; set; }
        public int t00rv42 { get; set; }
        public int t00rv5 { get; set; }
        public int t00rv51 { get; set; }
        public int t00rv52 { get; set; }
        public int t00rv6 { get; set; }
        public int t00rv61 { get; set; }
        public int t00rv62 { get; set; }
        public int t00rv7 { get; set; }
        public int t00rv71 { get; set; }
        public int t00rv72 { get; set; }
        public int t00rv8 { get; set; }
        public int t00rv81 { get; set; }
        public int t00rv82 { get; set; }
        public int t00rv9 { get; set; }
        public int t00rv91 { get; set; }
        public int t00rv92 { get; set; }
        public int t01dv { get; set; }
        public int t01dvl { get; set; }
        public int t01rv0 { get; set; }
        public int t01rv01 { get; set; }
        public int t01rv02 { get; set; }
        public int t01rv1 { get; set; }
        public int t01rv10 { get; set; }
        public int t01rv101 { get; set; }
        public int t01rv102 { get; set; }
        public int t01rv11 { get; set; }
        public int t01rv111 { get; set; }
        public int t01rv112 { get; set; }
        public int t01rv12 { get; set; }
        public int t01rv121 { get; set; }
        public int t01rv122 { get; set; }
        public int t01rv13 { get; set; }
        public int t01rv131 { get; set; }
        public int t01rv132 { get; set; }
        public int t01rv14 { get; set; }
        public int t01rv141 { get; set; }
        public int t01rv142 { get; set; }
        public int t01rv15 { get; set; }
        public int t01rv151 { get; set; }
        public int t01rv152 { get; set; }
        public int t01rv16 { get; set; }
        public int t01rv161 { get; set; }
        public int t01rv162 { get; set; }
        public int t01rv17 { get; set; }
        public int t01rv171 { get; set; }
        public int t01rv172 { get; set; }
        public int t01rv18 { get; set; }
        public int t01rv181 { get; set; }
        public int t01rv182 { get; set; }
        public int t01rv19 { get; set; }
        public int t01rv191 { get; set; }
        public int t01rv192 { get; set; }
        public int t01rv2 { get; set; }
        public int t01rv20 { get; set; }
        public int t01rv201 { get; set; }
        public int t01rv202 { get; set; }
        public int t01rv21 { get; set; }
        public int t01rv211 { get; set; }
        public int t01rv212 { get; set; }
        public int t01rv22 { get; set; }
        public int t01rv221 { get; set; }
        public int t01rv222 { get; set; }
        public int t01rv23 { get; set; }
        public int t01rv231 { get; set; }
        public int t01rv232 { get; set; }
        public int t01rv24 { get; set; }
        public int t01rv241 { get; set; }
        public int t01rv242 { get; set; }
        public int t01rv25 { get; set; }
        public int t01rv251 { get; set; }
        public int t01rv252 { get; set; }
        public int t01rv3 { get; set; }
        public int t01rv31 { get; set; }
        public int t01rv32 { get; set; }
        public int t01rv4 { get; set; }
        public int t01rv41 { get; set; }
        public int t01rv42 { get; set; }
        public int t01rv5 { get; set; }
        public int t01rv51 { get; set; }
        public int t01rv52 { get; set; }
        public int t01rv6 { get; set; }
        public int t01rv61 { get; set; }
        public int t01rv62 { get; set; }
        public int t01rv7 { get; set; }
        public int t01rv71 { get; set; }
        public int t01rv72 { get; set; }
        public int t01rv8 { get; set; }
        public int t01rv81 { get; set; }
        public int t01rv82 { get; set; }
        public int t01rv9 { get; set; }
        public int t01rv91 { get; set; }
        public int t01rv92 { get; set; }
        public int t02dv { get; set; }
        public int t02dvl { get; set; }
        public int t02rv0 { get; set; }
        public int t02rv01 { get; set; }
        public int t02rv02 { get; set; }
        public int t02rv1 { get; set; }
        public int t02rv10 { get; set; }
        public int t02rv101 { get; set; }
        public int t02rv102 { get; set; }
        public int t02rv11 { get; set; }
        public int t02rv111 { get; set; }
        public int t02rv112 { get; set; }
        public int t02rv12 { get; set; }
        public int t02rv121 { get; set; }
        public int t02rv122 { get; set; }
        public int t02rv13 { get; set; }
        public int t02rv131 { get; set; }
        public int t02rv132 { get; set; }
        public int t02rv14 { get; set; }
        public int t02rv141 { get; set; }
        public int t02rv142 { get; set; }
        public int t02rv15 { get; set; }
        public int t02rv151 { get; set; }
        public int t02rv152 { get; set; }
        public int t02rv16 { get; set; }
        public int t02rv161 { get; set; }
        public int t02rv162 { get; set; }
        public int t02rv17 { get; set; }
        public int t02rv171 { get; set; }
        public int t02rv172 { get; set; }
        public int t02rv18 { get; set; }
        public int t02rv181 { get; set; }
        public int t02rv182 { get; set; }
        public int t02rv19 { get; set; }
        public int t02rv191 { get; set; }
        public int t02rv192 { get; set; }
        public int t02rv2 { get; set; }
        public int t02rv20 { get; set; }
        public int t02rv201 { get; set; }
        public int t02rv202 { get; set; }
        public int t02rv21 { get; set; }
        public int t02rv211 { get; set; }
        public int t02rv212 { get; set; }
        public int t02rv22 { get; set; }
        public int t02rv221 { get; set; }
        public int t02rv222 { get; set; }
        public int t02rv23 { get; set; }
        public int t02rv231 { get; set; }
        public int t02rv232 { get; set; }
        public int t02rv24 { get; set; }
        public int t02rv241 { get; set; }
        public int t02rv242 { get; set; }
        public int t02rv25 { get; set; }
        public int t02rv251 { get; set; }
        public int t02rv252 { get; set; }
        public int t02rv3 { get; set; }
        public int t02rv31 { get; set; }
        public int t02rv32 { get; set; }
        public int t02rv4 { get; set; }
        public int t02rv41 { get; set; }
        public int t02rv42 { get; set; }
        public int t02rv5 { get; set; }
        public int t02rv51 { get; set; }
        public int t02rv52 { get; set; }
        public int t02rv6 { get; set; }
        public int t02rv61 { get; set; }
        public int t02rv62 { get; set; }
        public int t02rv7 { get; set; }
        public int t02rv71 { get; set; }
        public int t02rv72 { get; set; }
        public int t02rv8 { get; set; }
        public int t02rv81 { get; set; }
        public int t02rv82 { get; set; }
        public int t02rv9 { get; set; }
        public int t02rv91 { get; set; }
        public int t02rv92 { get; set; }
        public int t03dv { get; set; }
        public int t03dvl { get; set; }
        public int t03rv0 { get; set; }
        public int t03rv01 { get; set; }
        public int t03rv02 { get; set; }
        public int t03rv1 { get; set; }
        public int t03rv10 { get; set; }
        public int t03rv101 { get; set; }
        public int t03rv102 { get; set; }
        public int t03rv11 { get; set; }
        public int t03rv111 { get; set; }
        public int t03rv112 { get; set; }
        public int t03rv12 { get; set; }
        public int t03rv121 { get; set; }
        public int t03rv122 { get; set; }
        public int t03rv13 { get; set; }
        public int t03rv131 { get; set; }
        public int t03rv132 { get; set; }
        public int t03rv14 { get; set; }
        public int t03rv141 { get; set; }
        public int t03rv142 { get; set; }
        public int t03rv15 { get; set; }
        public int t03rv151 { get; set; }
        public int t03rv152 { get; set; }
        public int t03rv16 { get; set; }
        public int t03rv161 { get; set; }
        public int t03rv162 { get; set; }
        public int t03rv17 { get; set; }
        public int t03rv171 { get; set; }
        public int t03rv172 { get; set; }
        public int t03rv18 { get; set; }
        public int t03rv181 { get; set; }
        public int t03rv182 { get; set; }
        public int t03rv19 { get; set; }
        public int t03rv191 { get; set; }
        public int t03rv192 { get; set; }
        public int t03rv2 { get; set; }
        public int t03rv20 { get; set; }
        public int t03rv201 { get; set; }
        public int t03rv202 { get; set; }
        public int t03rv21 { get; set; }
        public int t03rv211 { get; set; }
        public int t03rv212 { get; set; }
        public int t03rv22 { get; set; }
        public int t03rv221 { get; set; }
        public int t03rv222 { get; set; }
        public int t03rv23 { get; set; }
        public int t03rv231 { get; set; }
        public int t03rv232 { get; set; }
        public int t03rv24 { get; set; }
        public int t03rv241 { get; set; }
        public int t03rv242 { get; set; }
        public int t03rv25 { get; set; }
        public int t03rv251 { get; set; }
        public int t03rv252 { get; set; }
        public int t03rv3 { get; set; }
        public int t03rv31 { get; set; }
        public int t03rv32 { get; set; }
        public int t03rv4 { get; set; }
        public int t03rv41 { get; set; }
        public int t03rv42 { get; set; }
        public int t03rv5 { get; set; }
        public int t03rv51 { get; set; }
        public int t03rv52 { get; set; }
        public int t03rv6 { get; set; }
        public int t03rv61 { get; set; }
        public int t03rv62 { get; set; }
        public int t03rv7 { get; set; }
        public int t03rv71 { get; set; }
        public int t03rv72 { get; set; }
        public int t03rv8 { get; set; }
        public int t03rv81 { get; set; }
        public int t03rv82 { get; set; }
        public int t03rv9 { get; set; }
        public int t03rv91 { get; set; }
        public int t03rv92 { get; set; }
        public int t0dv { get; set; }
        public int t0dvl { get; set; }
        public string t0fs0 { get; set; }
        public string t0fs1 { get; set; }
        public int t0vl0 { get; set; }
        public int t0vl01 { get; set; }
        public int t0vl02 { get; set; }
        public int t0vl1 { get; set; }
        public int t0vl10 { get; set; }
        public int t0vl101 { get; set; }
        public int t0vl102 { get; set; }
        public int t0vl11 { get; set; }
        public int t0vl111 { get; set; }
        public int t0vl112 { get; set; }
        public int t0vl12 { get; set; }
        public int t0vl121 { get; set; }
        public int t0vl122 { get; set; }
        public int t0vl13 { get; set; }
        public int t0vl131 { get; set; }
        public int t0vl132 { get; set; }
        public int t0vl14 { get; set; }
        public int t0vl141 { get; set; }
        public int t0vl142 { get; set; }
        public int t0vl15 { get; set; }
        public int t0vl151 { get; set; }
        public int t0vl152 { get; set; }
        public int t0vl16 { get; set; }
        public int t0vl161 { get; set; }
        public int t0vl162 { get; set; }
        public int t0vl17 { get; set; }
        public int t0vl171 { get; set; }
        public int t0vl172 { get; set; }
        public int t0vl18 { get; set; }
        public int t0vl181 { get; set; }
        public int t0vl182 { get; set; }
        public int t0vl19 { get; set; }
        public int t0vl191 { get; set; }
        public int t0vl192 { get; set; }
        public int t0vl2 { get; set; }
        public int t0vl20 { get; set; }
        public int t0vl201 { get; set; }
        public int t0vl202 { get; set; }
        public int t0vl21 { get; set; }
        public int t0vl211 { get; set; }
        public int t0vl212 { get; set; }
        public int t0vl22 { get; set; }
        public int t0vl221 { get; set; }
        public int t0vl222 { get; set; }
        public int t0vl23 { get; set; }
        public int t0vl231 { get; set; }
        public int t0vl232 { get; set; }
        public int t0vl24 { get; set; }
        public int t0vl241 { get; set; }
        public int t0vl242 { get; set; }
        public int t0vl25 { get; set; }
        public int t0vl251 { get; set; }
        public int t0vl252 { get; set; }
        public int t0vl3 { get; set; }
        public int t0vl31 { get; set; }
        public int t0vl32 { get; set; }
        public int t0vl4 { get; set; }
        public int t0vl41 { get; set; }
        public int t0vl42 { get; set; }
        public int t0vl5 { get; set; }
        public int t0vl51 { get; set; }
        public int t0vl52 { get; set; }
        public int t0vl6 { get; set; }
        public int t0vl61 { get; set; }
        public int t0vl62 { get; set; }
        public int t0vl7 { get; set; }
        public int t0vl71 { get; set; }
        public int t0vl72 { get; set; }
        public int t0vl8 { get; set; }
        public int t0vl81 { get; set; }
        public int t0vl82 { get; set; }
        public int t0vl9 { get; set; }
        public int t0vl91 { get; set; }
        public int t0vl92 { get; set; }
        public int t10dv { get; set; }
        public int t10dvl { get; set; }
        public int t10rv0 { get; set; }
        public int t10rv01 { get; set; }
        public int t10rv02 { get; set; }
        public int t10rv1 { get; set; }
        public int t10rv10 { get; set; }
        public int t10rv101 { get; set; }
        public int t10rv102 { get; set; }
        public int t10rv11 { get; set; }
        public int t10rv111 { get; set; }
        public int t10rv112 { get; set; }
        public int t10rv12 { get; set; }
        public int t10rv121 { get; set; }
        public int t10rv122 { get; set; }
        public int t10rv13 { get; set; }
        public int t10rv131 { get; set; }
        public int t10rv132 { get; set; }
        public int t10rv14 { get; set; }
        public int t10rv141 { get; set; }
        public int t10rv142 { get; set; }
        public int t10rv15 { get; set; }
        public int t10rv151 { get; set; }
        public int t10rv152 { get; set; }
        public int t10rv16 { get; set; }
        public int t10rv161 { get; set; }
        public int t10rv162 { get; set; }
        public int t10rv17 { get; set; }
        public int t10rv171 { get; set; }
        public int t10rv172 { get; set; }
        public int t10rv18 { get; set; }
        public int t10rv181 { get; set; }
        public int t10rv182 { get; set; }
        public int t10rv19 { get; set; }
        public int t10rv191 { get; set; }
        public int t10rv192 { get; set; }
        public int t10rv2 { get; set; }
        public int t10rv20 { get; set; }
        public int t10rv201 { get; set; }
        public int t10rv202 { get; set; }
        public int t10rv21 { get; set; }
        public int t10rv211 { get; set; }
        public int t10rv212 { get; set; }
        public int t10rv22 { get; set; }
        public int t10rv221 { get; set; }
        public int t10rv222 { get; set; }
        public int t10rv23 { get; set; }
        public int t10rv231 { get; set; }
        public int t10rv232 { get; set; }
        public int t10rv24 { get; set; }
        public int t10rv241 { get; set; }
        public int t10rv242 { get; set; }
        public int t10rv25 { get; set; }
        public int t10rv251 { get; set; }
        public int t10rv252 { get; set; }
        public int t10rv3 { get; set; }
        public int t10rv31 { get; set; }
        public int t10rv32 { get; set; }
        public int t10rv4 { get; set; }
        public int t10rv41 { get; set; }
        public int t10rv42 { get; set; }
        public int t10rv5 { get; set; }
        public int t10rv51 { get; set; }
        public int t10rv52 { get; set; }
        public int t10rv6 { get; set; }
        public int t10rv61 { get; set; }
        public int t10rv62 { get; set; }
        public int t10rv7 { get; set; }
        public int t10rv71 { get; set; }
        public int t10rv72 { get; set; }
        public int t10rv8 { get; set; }
        public int t10rv81 { get; set; }
        public int t10rv82 { get; set; }
        public int t10rv9 { get; set; }
        public int t10rv91 { get; set; }
        public int t10rv92 { get; set; }
        public int t11dv { get; set; }
        public int t11dvl { get; set; }
        public int t11rv0 { get; set; }
        public int t11rv01 { get; set; }
        public int t11rv02 { get; set; }
        public int t11rv1 { get; set; }
        public int t11rv10 { get; set; }
        public int t11rv101 { get; set; }
        public int t11rv102 { get; set; }
        public int t11rv11 { get; set; }
        public int t11rv111 { get; set; }
        public int t11rv112 { get; set; }
        public int t11rv12 { get; set; }
        public int t11rv121 { get; set; }
        public int t11rv122 { get; set; }
        public int t11rv13 { get; set; }
        public int t11rv131 { get; set; }
        public int t11rv132 { get; set; }
        public int t11rv14 { get; set; }
        public int t11rv141 { get; set; }
        public int t11rv142 { get; set; }
        public int t11rv15 { get; set; }
        public int t11rv151 { get; set; }
        public int t11rv152 { get; set; }
        public int t11rv16 { get; set; }
        public int t11rv161 { get; set; }
        public int t11rv162 { get; set; }
        public int t11rv17 { get; set; }
        public int t11rv171 { get; set; }
        public int t11rv172 { get; set; }
        public int t11rv18 { get; set; }
        public int t11rv181 { get; set; }
        public int t11rv182 { get; set; }
        public int t11rv19 { get; set; }
        public int t11rv191 { get; set; }
        public int t11rv192 { get; set; }
        public int t11rv2 { get; set; }
        public int t11rv20 { get; set; }
        public int t11rv201 { get; set; }
        public int t11rv202 { get; set; }
        public int t11rv21 { get; set; }
        public int t11rv211 { get; set; }
        public int t11rv212 { get; set; }
        public int t11rv22 { get; set; }
        public int t11rv221 { get; set; }
        public int t11rv222 { get; set; }
        public int t11rv23 { get; set; }
        public int t11rv231 { get; set; }
        public int t11rv232 { get; set; }
        public int t11rv24 { get; set; }
        public int t11rv241 { get; set; }
        public int t11rv242 { get; set; }
        public int t11rv25 { get; set; }
        public int t11rv251 { get; set; }
        public int t11rv252 { get; set; }
        public int t11rv3 { get; set; }
        public int t11rv31 { get; set; }
        public int t11rv32 { get; set; }
        public int t11rv4 { get; set; }
        public int t11rv41 { get; set; }
        public int t11rv42 { get; set; }
        public int t11rv5 { get; set; }
        public int t11rv51 { get; set; }
        public int t11rv52 { get; set; }
        public int t11rv6 { get; set; }
        public int t11rv61 { get; set; }
        public int t11rv62 { get; set; }
        public int t11rv7 { get; set; }
        public int t11rv71 { get; set; }
        public int t11rv72 { get; set; }
        public int t11rv8 { get; set; }
        public int t11rv81 { get; set; }
        public int t11rv82 { get; set; }
        public int t11rv9 { get; set; }
        public int t11rv91 { get; set; }
        public int t11rv92 { get; set; }
        public int t12dv { get; set; }
        public int t12dvl { get; set; }
        public int t12rv0 { get; set; }
        public int t12rv01 { get; set; }
        public int t12rv02 { get; set; }
        public int t12rv1 { get; set; }
        public int t12rv10 { get; set; }
        public int t12rv101 { get; set; }
        public int t12rv102 { get; set; }
        public int t12rv11 { get; set; }
        public int t12rv111 { get; set; }
        public int t12rv112 { get; set; }
        public int t12rv12 { get; set; }
        public int t12rv121 { get; set; }
        public int t12rv122 { get; set; }
        public int t12rv13 { get; set; }
        public int t12rv131 { get; set; }
        public int t12rv132 { get; set; }
        public int t12rv14 { get; set; }
        public int t12rv141 { get; set; }
        public int t12rv142 { get; set; }
        public int t12rv15 { get; set; }
        public int t12rv151 { get; set; }
        public int t12rv152 { get; set; }
        public int t12rv16 { get; set; }
        public int t12rv161 { get; set; }
        public int t12rv162 { get; set; }
        public int t12rv17 { get; set; }
        public int t12rv171 { get; set; }
        public int t12rv172 { get; set; }
        public int t12rv18 { get; set; }
        public int t12rv181 { get; set; }
        public int t12rv182 { get; set; }
        public int t12rv19 { get; set; }
        public int t12rv191 { get; set; }
        public int t12rv192 { get; set; }
        public int t12rv2 { get; set; }
        public int t12rv20 { get; set; }
        public int t12rv201 { get; set; }
        public int t12rv202 { get; set; }
        public int t12rv21 { get; set; }
        public int t12rv211 { get; set; }
        public int t12rv212 { get; set; }
        public int t12rv22 { get; set; }
        public int t12rv221 { get; set; }
        public int t12rv222 { get; set; }
        public int t12rv23 { get; set; }
        public int t12rv231 { get; set; }
        public int t12rv232 { get; set; }
        public int t12rv24 { get; set; }
        public int t12rv241 { get; set; }
        public int t12rv242 { get; set; }
        public int t12rv25 { get; set; }
        public int t12rv251 { get; set; }
        public int t12rv252 { get; set; }
        public int t12rv3 { get; set; }
        public int t12rv31 { get; set; }
        public int t12rv32 { get; set; }
        public int t12rv4 { get; set; }
        public int t12rv41 { get; set; }
        public int t12rv42 { get; set; }
        public int t12rv5 { get; set; }
        public int t12rv51 { get; set; }
        public int t12rv52 { get; set; }
        public int t12rv6 { get; set; }
        public int t12rv61 { get; set; }
        public int t12rv62 { get; set; }
        public int t12rv7 { get; set; }
        public int t12rv71 { get; set; }
        public int t12rv72 { get; set; }
        public int t12rv8 { get; set; }
        public int t12rv81 { get; set; }
        public int t12rv82 { get; set; }
        public int t12rv9 { get; set; }
        public int t12rv91 { get; set; }
        public int t12rv92 { get; set; }
        public int t13dv { get; set; }
        public int t13dvl { get; set; }
        public int t13rv0 { get; set; }
        public int t13rv01 { get; set; }
        public int t13rv02 { get; set; }
        public int t13rv1 { get; set; }
        public int t13rv10 { get; set; }
        public int t13rv101 { get; set; }
        public int t13rv102 { get; set; }
        public int t13rv11 { get; set; }
        public int t13rv111 { get; set; }
        public int t13rv112 { get; set; }
        public int t13rv12 { get; set; }
        public int t13rv121 { get; set; }
        public int t13rv122 { get; set; }
        public int t13rv13 { get; set; }
        public int t13rv131 { get; set; }
        public int t13rv132 { get; set; }
        public int t13rv14 { get; set; }
        public int t13rv141 { get; set; }
        public int t13rv142 { get; set; }
        public int t13rv15 { get; set; }
        public int t13rv151 { get; set; }
        public int t13rv152 { get; set; }
        public int t13rv16 { get; set; }
        public int t13rv161 { get; set; }
        public int t13rv162 { get; set; }
        public int t13rv17 { get; set; }
        public int t13rv171 { get; set; }
        public int t13rv172 { get; set; }
        public int t13rv18 { get; set; }
        public int t13rv181 { get; set; }
        public int t13rv182 { get; set; }
        public int t13rv19 { get; set; }
        public int t13rv191 { get; set; }
        public int t13rv192 { get; set; }
        public int t13rv2 { get; set; }
        public int t13rv20 { get; set; }
        public int t13rv201 { get; set; }
        public int t13rv202 { get; set; }
        public int t13rv21 { get; set; }
        public int t13rv211 { get; set; }
        public int t13rv212 { get; set; }
        public int t13rv22 { get; set; }
        public int t13rv221 { get; set; }
        public int t13rv222 { get; set; }
        public int t13rv23 { get; set; }
        public int t13rv231 { get; set; }
        public int t13rv232 { get; set; }
        public int t13rv24 { get; set; }
        public int t13rv241 { get; set; }
        public int t13rv242 { get; set; }
        public int t13rv25 { get; set; }
        public int t13rv251 { get; set; }
        public int t13rv252 { get; set; }
        public int t13rv3 { get; set; }
        public int t13rv31 { get; set; }
        public int t13rv32 { get; set; }
        public int t13rv4 { get; set; }
        public int t13rv41 { get; set; }
        public int t13rv42 { get; set; }
        public int t13rv5 { get; set; }
        public int t13rv51 { get; set; }
        public int t13rv52 { get; set; }
        public int t13rv6 { get; set; }
        public int t13rv61 { get; set; }
        public int t13rv62 { get; set; }
        public int t13rv7 { get; set; }
        public int t13rv71 { get; set; }
        public int t13rv72 { get; set; }
        public int t13rv8 { get; set; }
        public int t13rv81 { get; set; }
        public int t13rv82 { get; set; }
        public int t13rv9 { get; set; }
        public int t13rv91 { get; set; }
        public int t13rv92 { get; set; }
        public int t1dv { get; set; }
        public int t1dvl { get; set; }
        public string t1fs0 { get; set; }
        public string t1fs1 { get; set; }
        public int t1vl0 { get; set; }
        public int t1vl01 { get; set; }
        public int t1vl02 { get; set; }
        public int t1vl1 { get; set; }
        public int t1vl10 { get; set; }
        public int t1vl101 { get; set; }
        public int t1vl102 { get; set; }
        public int t1vl11 { get; set; }
        public int t1vl111 { get; set; }
        public int t1vl112 { get; set; }
        public int t1vl12 { get; set; }
        public int t1vl121 { get; set; }
        public int t1vl122 { get; set; }
        public int t1vl13 { get; set; }
        public int t1vl131 { get; set; }
        public int t1vl132 { get; set; }
        public int t1vl14 { get; set; }
        public int t1vl141 { get; set; }
        public int t1vl142 { get; set; }
        public int t1vl15 { get; set; }
        public int t1vl151 { get; set; }
        public int t1vl152 { get; set; }
        public int t1vl16 { get; set; }
        public int t1vl161 { get; set; }
        public int t1vl162 { get; set; }
        public int t1vl17 { get; set; }
        public int t1vl171 { get; set; }
        public int t1vl172 { get; set; }
        public int t1vl18 { get; set; }
        public int t1vl181 { get; set; }
        public int t1vl182 { get; set; }
        public int t1vl19 { get; set; }
        public int t1vl191 { get; set; }
        public int t1vl192 { get; set; }
        public int t1vl2 { get; set; }
        public int t1vl20 { get; set; }
        public int t1vl201 { get; set; }
        public int t1vl202 { get; set; }
        public int t1vl21 { get; set; }
        public int t1vl211 { get; set; }
        public int t1vl212 { get; set; }
        public int t1vl22 { get; set; }
        public int t1vl221 { get; set; }
        public int t1vl222 { get; set; }
        public int t1vl23 { get; set; }
        public int t1vl231 { get; set; }
        public int t1vl232 { get; set; }
        public int t1vl24 { get; set; }
        public int t1vl241 { get; set; }
        public int t1vl242 { get; set; }
        public int t1vl25 { get; set; }
        public int t1vl251 { get; set; }
        public int t1vl252 { get; set; }
        public int t1vl3 { get; set; }
        public int t1vl31 { get; set; }
        public int t1vl32 { get; set; }
        public int t1vl4 { get; set; }
        public int t1vl41 { get; set; }
        public int t1vl42 { get; set; }
        public int t1vl5 { get; set; }
        public int t1vl51 { get; set; }
        public int t1vl52 { get; set; }
        public int t1vl6 { get; set; }
        public int t1vl61 { get; set; }
        public int t1vl62 { get; set; }
        public int t1vl7 { get; set; }
        public int t1vl71 { get; set; }
        public int t1vl72 { get; set; }
        public int t1vl8 { get; set; }
        public int t1vl81 { get; set; }
        public int t1vl82 { get; set; }
        public int t1vl9 { get; set; }
        public int t1vl91 { get; set; }
        public int t1vl92 { get; set; }
        public int t20dv { get; set; }
        public int t20dvl { get; set; }
        public int t20rv0 { get; set; }
        public int t20rv01 { get; set; }
        public int t20rv02 { get; set; }
        public int t20rv1 { get; set; }
        public int t20rv10 { get; set; }
        public int t20rv101 { get; set; }
        public int t20rv102 { get; set; }
        public int t20rv11 { get; set; }
        public int t20rv111 { get; set; }
        public int t20rv112 { get; set; }
        public int t20rv12 { get; set; }
        public int t20rv121 { get; set; }
        public int t20rv122 { get; set; }
        public int t20rv13 { get; set; }
        public int t20rv131 { get; set; }
        public int t20rv132 { get; set; }
        public int t20rv14 { get; set; }
        public int t20rv141 { get; set; }
        public int t20rv142 { get; set; }
        public int t20rv15 { get; set; }
        public int t20rv151 { get; set; }
        public int t20rv152 { get; set; }
        public int t20rv16 { get; set; }
        public int t20rv161 { get; set; }
        public int t20rv162 { get; set; }
        public int t20rv17 { get; set; }
        public int t20rv171 { get; set; }
        public int t20rv172 { get; set; }
        public int t20rv18 { get; set; }
        public int t20rv181 { get; set; }
        public int t20rv182 { get; set; }
        public int t20rv19 { get; set; }
        public int t20rv191 { get; set; }
        public int t20rv192 { get; set; }
        public int t20rv2 { get; set; }
        public int t20rv20 { get; set; }
        public int t20rv201 { get; set; }
        public int t20rv202 { get; set; }
        public int t20rv21 { get; set; }
        public int t20rv211 { get; set; }
        public int t20rv212 { get; set; }
        public int t20rv22 { get; set; }
        public int t20rv221 { get; set; }
        public int t20rv222 { get; set; }
        public int t20rv23 { get; set; }
        public int t20rv231 { get; set; }
        public int t20rv232 { get; set; }
        public int t20rv24 { get; set; }
        public int t20rv241 { get; set; }
        public int t20rv242 { get; set; }
        public int t20rv25 { get; set; }
        public int t20rv251 { get; set; }
        public int t20rv252 { get; set; }
        public int t20rv3 { get; set; }
        public int t20rv31 { get; set; }
        public int t20rv32 { get; set; }
        public int t20rv4 { get; set; }
        public int t20rv41 { get; set; }
        public int t20rv42 { get; set; }
        public int t20rv5 { get; set; }
        public int t20rv51 { get; set; }
        public int t20rv52 { get; set; }
        public int t20rv6 { get; set; }
        public int t20rv61 { get; set; }
        public int t20rv62 { get; set; }
        public int t20rv7 { get; set; }
        public int t20rv71 { get; set; }
        public int t20rv72 { get; set; }
        public int t20rv8 { get; set; }
        public int t20rv81 { get; set; }
        public int t20rv82 { get; set; }
        public int t20rv9 { get; set; }
        public int t20rv91 { get; set; }
        public int t20rv92 { get; set; }
        public int t21dv { get; set; }
        public int t21dvl { get; set; }
        public int t21rv0 { get; set; }
        public int t21rv01 { get; set; }
        public int t21rv02 { get; set; }
        public int t21rv1 { get; set; }
        public int t21rv10 { get; set; }
        public int t21rv101 { get; set; }
        public int t21rv102 { get; set; }
        public int t21rv11 { get; set; }
        public int t21rv111 { get; set; }
        public int t21rv112 { get; set; }
        public int t21rv12 { get; set; }
        public int t21rv121 { get; set; }
        public int t21rv122 { get; set; }
        public int t21rv13 { get; set; }
        public int t21rv131 { get; set; }
        public int t21rv132 { get; set; }
        public int t21rv14 { get; set; }
        public int t21rv141 { get; set; }
        public int t21rv142 { get; set; }
        public int t21rv15 { get; set; }
        public int t21rv151 { get; set; }
        public int t21rv152 { get; set; }
        public int t21rv16 { get; set; }
        public int t21rv161 { get; set; }
        public int t21rv162 { get; set; }
        public int t21rv17 { get; set; }
        public int t21rv171 { get; set; }
        public int t21rv172 { get; set; }
        public int t21rv18 { get; set; }
        public int t21rv181 { get; set; }
        public int t21rv182 { get; set; }
        public int t21rv19 { get; set; }
        public int t21rv191 { get; set; }
        public int t21rv192 { get; set; }
        public int t21rv2 { get; set; }
        public int t21rv20 { get; set; }
        public int t21rv201 { get; set; }
        public int t21rv202 { get; set; }
        public int t21rv21 { get; set; }
        public int t21rv211 { get; set; }
        public int t21rv212 { get; set; }
        public int t21rv22 { get; set; }
        public int t21rv221 { get; set; }
        public int t21rv222 { get; set; }
        public int t21rv23 { get; set; }
        public int t21rv231 { get; set; }
        public int t21rv232 { get; set; }
        public int t21rv24 { get; set; }
        public int t21rv241 { get; set; }
        public int t21rv242 { get; set; }
        public int t21rv25 { get; set; }
        public int t21rv251 { get; set; }
        public int t21rv252 { get; set; }
        public int t21rv3 { get; set; }
        public int t21rv31 { get; set; }
        public int t21rv32 { get; set; }
        public int t21rv4 { get; set; }
        public int t21rv41 { get; set; }
        public int t21rv42 { get; set; }
        public int t21rv5 { get; set; }
        public int t21rv51 { get; set; }
        public int t21rv52 { get; set; }
        public int t21rv6 { get; set; }
        public int t21rv61 { get; set; }
        public int t21rv62 { get; set; }
        public int t21rv7 { get; set; }
        public int t21rv71 { get; set; }
        public int t21rv72 { get; set; }
        public int t21rv8 { get; set; }
        public int t21rv81 { get; set; }
        public int t21rv82 { get; set; }
        public int t21rv9 { get; set; }
        public int t21rv91 { get; set; }
        public int t21rv92 { get; set; }
        public int t22dv { get; set; }
        public int t22dvl { get; set; }
        public int t22rv0 { get; set; }
        public int t22rv01 { get; set; }
        public int t22rv02 { get; set; }
        public int t22rv1 { get; set; }
        public int t22rv10 { get; set; }
        public int t22rv101 { get; set; }
        public int t22rv102 { get; set; }
        public int t22rv11 { get; set; }
        public int t22rv111 { get; set; }
        public int t22rv112 { get; set; }
        public int t22rv12 { get; set; }
        public int t22rv121 { get; set; }
        public int t22rv122 { get; set; }
        public int t22rv13 { get; set; }
        public int t22rv131 { get; set; }
        public int t22rv132 { get; set; }
        public int t22rv14 { get; set; }
        public int t22rv141 { get; set; }
        public int t22rv142 { get; set; }
        public int t22rv15 { get; set; }
        public int t22rv151 { get; set; }
        public int t22rv152 { get; set; }
        public int t22rv16 { get; set; }
        public int t22rv161 { get; set; }
        public int t22rv162 { get; set; }
        public int t22rv17 { get; set; }
        public int t22rv171 { get; set; }
        public int t22rv172 { get; set; }
        public int t22rv18 { get; set; }
        public int t22rv181 { get; set; }
        public int t22rv182 { get; set; }
        public int t22rv19 { get; set; }
        public int t22rv191 { get; set; }
        public int t22rv192 { get; set; }
        public int t22rv2 { get; set; }
        public int t22rv20 { get; set; }
        public int t22rv201 { get; set; }
        public int t22rv202 { get; set; }
        public int t22rv21 { get; set; }
        public int t22rv211 { get; set; }
        public int t22rv212 { get; set; }
        public int t22rv22 { get; set; }
        public int t22rv221 { get; set; }
        public int t22rv222 { get; set; }
        public int t22rv23 { get; set; }
        public int t22rv231 { get; set; }
        public int t22rv232 { get; set; }
        public int t22rv24 { get; set; }
        public int t22rv241 { get; set; }
        public int t22rv242 { get; set; }
        public int t22rv25 { get; set; }
        public int t22rv251 { get; set; }
        public int t22rv252 { get; set; }
        public int t22rv3 { get; set; }
        public int t22rv31 { get; set; }
        public int t22rv32 { get; set; }
        public int t22rv4 { get; set; }
        public int t22rv41 { get; set; }
        public int t22rv42 { get; set; }
        public int t22rv5 { get; set; }
        public int t22rv51 { get; set; }
        public int t22rv52 { get; set; }
        public int t22rv6 { get; set; }
        public int t22rv61 { get; set; }
        public int t22rv62 { get; set; }
        public int t22rv7 { get; set; }
        public int t22rv71 { get; set; }
        public int t22rv72 { get; set; }
        public int t22rv8 { get; set; }
        public int t22rv81 { get; set; }
        public int t22rv82 { get; set; }
        public int t22rv9 { get; set; }
        public int t22rv91 { get; set; }
        public int t22rv92 { get; set; }
        public int t23dv { get; set; }
        public int t23dvl { get; set; }
        public int t23rv0 { get; set; }
        public int t23rv01 { get; set; }
        public int t23rv02 { get; set; }
        public int t23rv1 { get; set; }
        public int t23rv10 { get; set; }
        public int t23rv101 { get; set; }
        public int t23rv102 { get; set; }
        public int t23rv11 { get; set; }
        public int t23rv111 { get; set; }
        public int t23rv112 { get; set; }
        public int t23rv12 { get; set; }
        public int t23rv121 { get; set; }
        public int t23rv122 { get; set; }
        public int t23rv13 { get; set; }
        public int t23rv131 { get; set; }
        public int t23rv132 { get; set; }
        public int t23rv14 { get; set; }
        public int t23rv141 { get; set; }
        public int t23rv142 { get; set; }
        public int t23rv15 { get; set; }
        public int t23rv151 { get; set; }
        public int t23rv152 { get; set; }
        public int t23rv16 { get; set; }
        public int t23rv161 { get; set; }
        public int t23rv162 { get; set; }
        public int t23rv17 { get; set; }
        public int t23rv171 { get; set; }
        public int t23rv172 { get; set; }
        public int t23rv18 { get; set; }
        public int t23rv181 { get; set; }
        public int t23rv182 { get; set; }
        public int t23rv19 { get; set; }
        public int t23rv191 { get; set; }
        public int t23rv192 { get; set; }
        public int t23rv2 { get; set; }
        public int t23rv20 { get; set; }
        public int t23rv201 { get; set; }
        public int t23rv202 { get; set; }
        public int t23rv21 { get; set; }
        public int t23rv211 { get; set; }
        public int t23rv212 { get; set; }
        public int t23rv22 { get; set; }
        public int t23rv221 { get; set; }
        public int t23rv222 { get; set; }
        public int t23rv23 { get; set; }
        public int t23rv231 { get; set; }
        public int t23rv232 { get; set; }
        public int t23rv24 { get; set; }
        public int t23rv241 { get; set; }
        public int t23rv242 { get; set; }
        public int t23rv25 { get; set; }
        public int t23rv251 { get; set; }
        public int t23rv252 { get; set; }
        public int t23rv3 { get; set; }
        public int t23rv31 { get; set; }
        public int t23rv32 { get; set; }
        public int t23rv4 { get; set; }
        public int t23rv41 { get; set; }
        public int t23rv42 { get; set; }
        public int t23rv5 { get; set; }
        public int t23rv51 { get; set; }
        public int t23rv52 { get; set; }
        public int t23rv6 { get; set; }
        public int t23rv61 { get; set; }
        public int t23rv62 { get; set; }
        public int t23rv7 { get; set; }
        public int t23rv71 { get; set; }
        public int t23rv72 { get; set; }
        public int t23rv8 { get; set; }
        public int t23rv81 { get; set; }
        public int t23rv82 { get; set; }
        public int t23rv9 { get; set; }
        public int t23rv91 { get; set; }
        public int t23rv92 { get; set; }
        public int t2dv { get; set; }
        public int t2dvl { get; set; }
        public string t2fs0 { get; set; }
        public string t2fs1 { get; set; }
        public int t2vl0 { get; set; }
        public int t2vl01 { get; set; }
        public int t2vl02 { get; set; }
        public int t2vl1 { get; set; }
        public int t2vl10 { get; set; }
        public int t2vl101 { get; set; }
        public int t2vl102 { get; set; }
        public int t2vl11 { get; set; }
        public int t2vl111 { get; set; }
        public int t2vl112 { get; set; }
        public int t2vl12 { get; set; }
        public int t2vl121 { get; set; }
        public int t2vl122 { get; set; }
        public int t2vl13 { get; set; }
        public int t2vl131 { get; set; }
        public int t2vl132 { get; set; }
        public int t2vl14 { get; set; }
        public int t2vl141 { get; set; }
        public int t2vl142 { get; set; }
        public int t2vl15 { get; set; }
        public int t2vl151 { get; set; }
        public int t2vl152 { get; set; }
        public int t2vl16 { get; set; }
        public int t2vl161 { get; set; }
        public int t2vl162 { get; set; }
        public int t2vl17 { get; set; }
        public int t2vl171 { get; set; }
        public int t2vl172 { get; set; }
        public int t2vl18 { get; set; }
        public int t2vl181 { get; set; }
        public int t2vl182 { get; set; }
        public int t2vl19 { get; set; }
        public int t2vl191 { get; set; }
        public int t2vl192 { get; set; }
        public int t2vl2 { get; set; }
        public int t2vl20 { get; set; }
        public int t2vl201 { get; set; }
        public int t2vl202 { get; set; }
        public int t2vl21 { get; set; }
        public int t2vl211 { get; set; }
        public int t2vl212 { get; set; }
        public int t2vl22 { get; set; }
        public int t2vl221 { get; set; }
        public int t2vl222 { get; set; }
        public int t2vl23 { get; set; }
        public int t2vl231 { get; set; }
        public int t2vl232 { get; set; }
        public int t2vl24 { get; set; }
        public int t2vl241 { get; set; }
        public int t2vl242 { get; set; }
        public int t2vl25 { get; set; }
        public int t2vl251 { get; set; }
        public int t2vl252 { get; set; }
        public int t2vl3 { get; set; }
        public int t2vl31 { get; set; }
        public int t2vl32 { get; set; }
        public int t2vl4 { get; set; }
        public int t2vl41 { get; set; }
        public int t2vl42 { get; set; }
        public int t2vl5 { get; set; }
        public int t2vl51 { get; set; }
        public int t2vl52 { get; set; }
        public int t2vl6 { get; set; }
        public int t2vl61 { get; set; }
        public int t2vl62 { get; set; }
        public int t2vl7 { get; set; }
        public int t2vl71 { get; set; }
        public int t2vl72 { get; set; }
        public int t2vl8 { get; set; }
        public int t2vl81 { get; set; }
        public int t2vl82 { get; set; }
        public int t2vl9 { get; set; }
        public int t2vl91 { get; set; }
        public int t2vl92 { get; set; }
        public int t30dv { get; set; }
        public int t30dvl { get; set; }
        public int t30rv0 { get; set; }
        public int t30rv01 { get; set; }
        public int t30rv02 { get; set; }
        public int t30rv1 { get; set; }
        public int t30rv10 { get; set; }
        public int t30rv101 { get; set; }
        public int t30rv102 { get; set; }
        public int t30rv11 { get; set; }
        public int t30rv111 { get; set; }
        public int t30rv112 { get; set; }
        public int t30rv12 { get; set; }
        public int t30rv121 { get; set; }
        public int t30rv122 { get; set; }
        public int t30rv13 { get; set; }
        public int t30rv131 { get; set; }
        public int t30rv132 { get; set; }
        public int t30rv14 { get; set; }
        public int t30rv141 { get; set; }
        public int t30rv142 { get; set; }
        public int t30rv15 { get; set; }
        public int t30rv151 { get; set; }
        public int t30rv152 { get; set; }
        public int t30rv16 { get; set; }
        public int t30rv161 { get; set; }
        public int t30rv162 { get; set; }
        public int t30rv17 { get; set; }
        public int t30rv171 { get; set; }
        public int t30rv172 { get; set; }
        public int t30rv18 { get; set; }
        public int t30rv181 { get; set; }
        public int t30rv182 { get; set; }
        public int t30rv19 { get; set; }
        public int t30rv191 { get; set; }
        public int t30rv192 { get; set; }
        public int t30rv2 { get; set; }
        public int t30rv20 { get; set; }
        public int t30rv201 { get; set; }
        public int t30rv202 { get; set; }
        public int t30rv21 { get; set; }
        public int t30rv211 { get; set; }
        public int t30rv212 { get; set; }
        public int t30rv22 { get; set; }
        public int t30rv221 { get; set; }
        public int t30rv222 { get; set; }
        public int t30rv23 { get; set; }
        public int t30rv231 { get; set; }
        public int t30rv232 { get; set; }
        public int t30rv24 { get; set; }
        public int t30rv241 { get; set; }
        public int t30rv242 { get; set; }
        public int t30rv25 { get; set; }
        public int t30rv251 { get; set; }
        public int t30rv252 { get; set; }
        public int t30rv3 { get; set; }
        public int t30rv31 { get; set; }
        public int t30rv32 { get; set; }
        public int t30rv4 { get; set; }
        public int t30rv41 { get; set; }
        public int t30rv42 { get; set; }
        public int t30rv5 { get; set; }
        public int t30rv51 { get; set; }
        public int t30rv52 { get; set; }
        public int t30rv6 { get; set; }
        public int t30rv61 { get; set; }
        public int t30rv62 { get; set; }
        public int t30rv7 { get; set; }
        public int t30rv71 { get; set; }
        public int t30rv72 { get; set; }
        public int t30rv8 { get; set; }
        public int t30rv81 { get; set; }
        public int t30rv82 { get; set; }
        public int t30rv9 { get; set; }
        public int t30rv91 { get; set; }
        public int t30rv92 { get; set; }
        public int t31dv { get; set; }
        public int t31dvl { get; set; }
        public int t31rv0 { get; set; }
        public int t31rv01 { get; set; }
        public int t31rv02 { get; set; }
        public int t31rv1 { get; set; }
        public int t31rv10 { get; set; }
        public int t31rv101 { get; set; }
        public int t31rv102 { get; set; }
        public int t31rv11 { get; set; }
        public int t31rv111 { get; set; }
        public int t31rv112 { get; set; }
        public int t31rv12 { get; set; }
        public int t31rv121 { get; set; }
        public int t31rv122 { get; set; }
        public int t31rv13 { get; set; }
        public int t31rv131 { get; set; }
        public int t31rv132 { get; set; }
        public int t31rv14 { get; set; }
        public int t31rv141 { get; set; }
        public int t31rv142 { get; set; }
        public int t31rv15 { get; set; }
        public int t31rv151 { get; set; }
        public int t31rv152 { get; set; }
        public int t31rv16 { get; set; }
        public int t31rv161 { get; set; }
        public int t31rv162 { get; set; }
        public int t31rv17 { get; set; }
        public int t31rv171 { get; set; }
        public int t31rv172 { get; set; }
        public int t31rv18 { get; set; }
        public int t31rv181 { get; set; }
        public int t31rv182 { get; set; }
        public int t31rv19 { get; set; }
        public int t31rv191 { get; set; }
        public int t31rv192 { get; set; }
        public int t31rv2 { get; set; }
        public int t31rv20 { get; set; }
        public int t31rv201 { get; set; }
        public int t31rv202 { get; set; }
        public int t31rv21 { get; set; }
        public int t31rv211 { get; set; }
        public int t31rv212 { get; set; }
        public int t31rv22 { get; set; }
        public int t31rv221 { get; set; }
        public int t31rv222 { get; set; }
        public int t31rv23 { get; set; }
        public int t31rv231 { get; set; }
        public int t31rv232 { get; set; }
        public int t31rv24 { get; set; }
        public int t31rv241 { get; set; }
        public int t31rv242 { get; set; }
        public int t31rv25 { get; set; }
        public int t31rv251 { get; set; }
        public int t31rv252 { get; set; }
        public int t31rv3 { get; set; }
        public int t31rv31 { get; set; }
        public int t31rv32 { get; set; }
        public int t31rv4 { get; set; }
        public int t31rv41 { get; set; }
        public int t31rv42 { get; set; }
        public int t31rv5 { get; set; }
        public int t31rv51 { get; set; }
        public int t31rv52 { get; set; }
        public int t31rv6 { get; set; }
        public int t31rv61 { get; set; }
        public int t31rv62 { get; set; }
        public int t31rv7 { get; set; }
        public int t31rv71 { get; set; }
        public int t31rv72 { get; set; }
        public int t31rv8 { get; set; }
        public int t31rv81 { get; set; }
        public int t31rv82 { get; set; }
        public int t31rv9 { get; set; }
        public int t31rv91 { get; set; }
        public int t31rv92 { get; set; }
        public int t32dv { get; set; }
        public int t32dvl { get; set; }
        public int t32rv0 { get; set; }
        public int t32rv01 { get; set; }
        public int t32rv02 { get; set; }
        public int t32rv1 { get; set; }
        public int t32rv10 { get; set; }
        public int t32rv101 { get; set; }
        public int t32rv102 { get; set; }
        public int t32rv11 { get; set; }
        public int t32rv111 { get; set; }
        public int t32rv112 { get; set; }
        public int t32rv12 { get; set; }
        public int t32rv121 { get; set; }
        public int t32rv122 { get; set; }
        public int t32rv13 { get; set; }
        public int t32rv131 { get; set; }
        public int t32rv132 { get; set; }
        public int t32rv14 { get; set; }
        public int t32rv141 { get; set; }
        public int t32rv142 { get; set; }
        public int t32rv15 { get; set; }
        public int t32rv151 { get; set; }
        public int t32rv152 { get; set; }
        public int t32rv16 { get; set; }
        public int t32rv161 { get; set; }
        public int t32rv162 { get; set; }
        public int t32rv17 { get; set; }
        public int t32rv171 { get; set; }
        public int t32rv172 { get; set; }
        public int t32rv18 { get; set; }
        public int t32rv181 { get; set; }
        public int t32rv182 { get; set; }
        public int t32rv19 { get; set; }
        public int t32rv191 { get; set; }
        public int t32rv192 { get; set; }
        public int t32rv2 { get; set; }
        public int t32rv20 { get; set; }
        public int t32rv201 { get; set; }
        public int t32rv202 { get; set; }
        public int t32rv21 { get; set; }
        public int t32rv211 { get; set; }
        public int t32rv212 { get; set; }
        public int t32rv22 { get; set; }
        public int t32rv221 { get; set; }
        public int t32rv222 { get; set; }
        public int t32rv23 { get; set; }
        public int t32rv231 { get; set; }
        public int t32rv232 { get; set; }
        public int t32rv24 { get; set; }
        public int t32rv241 { get; set; }
        public int t32rv242 { get; set; }
        public int t32rv25 { get; set; }
        public int t32rv251 { get; set; }
        public int t32rv252 { get; set; }
        public int t32rv3 { get; set; }
        public int t32rv31 { get; set; }
        public int t32rv32 { get; set; }
        public int t32rv4 { get; set; }
        public int t32rv41 { get; set; }
        public int t32rv42 { get; set; }
        public int t32rv5 { get; set; }
        public int t32rv51 { get; set; }
        public int t32rv52 { get; set; }
        public int t32rv6 { get; set; }
        public int t32rv61 { get; set; }
        public int t32rv62 { get; set; }
        public int t32rv7 { get; set; }
        public int t32rv71 { get; set; }
        public int t32rv72 { get; set; }
        public int t32rv8 { get; set; }
        public int t32rv81 { get; set; }
        public int t32rv82 { get; set; }
        public int t32rv9 { get; set; }
        public int t32rv91 { get; set; }
        public int t32rv92 { get; set; }
        public int t33dv { get; set; }
        public int t33dvl { get; set; }
        public int t33rv0 { get; set; }
        public int t33rv01 { get; set; }
        public int t33rv02 { get; set; }
        public int t33rv1 { get; set; }
        public int t33rv10 { get; set; }
        public int t33rv101 { get; set; }
        public int t33rv102 { get; set; }
        public int t33rv11 { get; set; }
        public int t33rv111 { get; set; }
        public int t33rv112 { get; set; }
        public int t33rv12 { get; set; }
        public int t33rv121 { get; set; }
        public int t33rv122 { get; set; }
        public int t33rv13 { get; set; }
        public int t33rv131 { get; set; }
        public int t33rv132 { get; set; }
        public int t33rv14 { get; set; }
        public int t33rv141 { get; set; }
        public int t33rv142 { get; set; }
        public int t33rv15 { get; set; }
        public int t33rv151 { get; set; }
        public int t33rv152 { get; set; }
        public int t33rv16 { get; set; }
        public int t33rv161 { get; set; }
        public int t33rv162 { get; set; }
        public int t33rv17 { get; set; }
        public int t33rv171 { get; set; }
        public int t33rv172 { get; set; }
        public int t33rv18 { get; set; }
        public int t33rv181 { get; set; }
        public int t33rv182 { get; set; }
        public int t33rv19 { get; set; }
        public int t33rv191 { get; set; }
        public int t33rv192 { get; set; }
        public int t33rv2 { get; set; }
        public int t33rv20 { get; set; }
        public int t33rv201 { get; set; }
        public int t33rv202 { get; set; }
        public int t33rv21 { get; set; }
        public int t33rv211 { get; set; }
        public int t33rv212 { get; set; }
        public int t33rv22 { get; set; }
        public int t33rv221 { get; set; }
        public int t33rv222 { get; set; }
        public int t33rv23 { get; set; }
        public int t33rv231 { get; set; }
        public int t33rv232 { get; set; }
        public int t33rv24 { get; set; }
        public int t33rv241 { get; set; }
        public int t33rv242 { get; set; }
        public int t33rv25 { get; set; }
        public int t33rv251 { get; set; }
        public int t33rv252 { get; set; }
        public int t33rv3 { get; set; }
        public int t33rv31 { get; set; }
        public int t33rv32 { get; set; }
        public int t33rv4 { get; set; }
        public int t33rv41 { get; set; }
        public int t33rv42 { get; set; }
        public int t33rv5 { get; set; }
        public int t33rv51 { get; set; }
        public int t33rv52 { get; set; }
        public int t33rv6 { get; set; }
        public int t33rv61 { get; set; }
        public int t33rv62 { get; set; }
        public int t33rv7 { get; set; }
        public int t33rv71 { get; set; }
        public int t33rv72 { get; set; }
        public int t33rv8 { get; set; }
        public int t33rv81 { get; set; }
        public int t33rv82 { get; set; }
        public int t33rv9 { get; set; }
        public int t33rv91 { get; set; }
        public int t33rv92 { get; set; }
        public int t3dv { get; set; }
        public int t3dvl { get; set; }
        public string t3fs0 { get; set; }
        public string t3fs1 { get; set; }
        public int t3vl0 { get; set; }
        public int t3vl01 { get; set; }
        public int t3vl02 { get; set; }
        public int t3vl1 { get; set; }
        public int t3vl10 { get; set; }
        public int t3vl101 { get; set; }
        public int t3vl102 { get; set; }
        public int t3vl11 { get; set; }
        public int t3vl111 { get; set; }
        public int t3vl112 { get; set; }
        public int t3vl12 { get; set; }
        public int t3vl121 { get; set; }
        public int t3vl122 { get; set; }
        public int t3vl13 { get; set; }
        public int t3vl131 { get; set; }
        public int t3vl132 { get; set; }
        public int t3vl14 { get; set; }
        public int t3vl141 { get; set; }
        public int t3vl142 { get; set; }
        public int t3vl15 { get; set; }
        public int t3vl151 { get; set; }
        public int t3vl152 { get; set; }
        public int t3vl16 { get; set; }
        public int t3vl161 { get; set; }
        public int t3vl162 { get; set; }
        public int t3vl17 { get; set; }
        public int t3vl171 { get; set; }
        public int t3vl172 { get; set; }
        public int t3vl18 { get; set; }
        public int t3vl181 { get; set; }
        public int t3vl182 { get; set; }
        public int t3vl19 { get; set; }
        public int t3vl191 { get; set; }
        public int t3vl192 { get; set; }
        public int t3vl2 { get; set; }
        public int t3vl20 { get; set; }
        public int t3vl201 { get; set; }
        public int t3vl202 { get; set; }
        public int t3vl21 { get; set; }
        public int t3vl211 { get; set; }
        public int t3vl212 { get; set; }
        public int t3vl22 { get; set; }
        public int t3vl221 { get; set; }
        public int t3vl222 { get; set; }
        public int t3vl23 { get; set; }
        public int t3vl231 { get; set; }
        public int t3vl232 { get; set; }
        public int t3vl24 { get; set; }
        public int t3vl241 { get; set; }
        public int t3vl242 { get; set; }
        public int t3vl25 { get; set; }
        public int t3vl251 { get; set; }
        public int t3vl252 { get; set; }
        public int t3vl3 { get; set; }
        public int t3vl31 { get; set; }
        public int t3vl32 { get; set; }
        public int t3vl4 { get; set; }
        public int t3vl41 { get; set; }
        public int t3vl42 { get; set; }
        public int t3vl5 { get; set; }
        public int t3vl51 { get; set; }
        public int t3vl52 { get; set; }
        public int t3vl6 { get; set; }
        public int t3vl61 { get; set; }
        public int t3vl62 { get; set; }
        public int t3vl7 { get; set; }
        public int t3vl71 { get; set; }
        public int t3vl72 { get; set; }
        public int t3vl8 { get; set; }
        public int t3vl81 { get; set; }
        public int t3vl82 { get; set; }
        public int t3vl9 { get; set; }
        public int t3vl91 { get; set; }
        public int t3vl92 { get; set; }
        public int tblty0 { get; set; }
        public int tblty1 { get; set; }
        public int tblty2 { get; set; }
        public int tblty3 { get; set; }
        public int tcmin0 { get; set; }
        public int tcmin1 { get; set; }
        public int tcmin2 { get; set; }
        public int tcmin3 { get; set; }
        public int teamvbs { get; set; }
        public int testcomplete { get; set; }
        public int tgtmcd { get; set; }
        public int time { get; set; }
        public float tmrees0 { get; set; }
        public float tmrees1 { get; set; }
        public float tmrees2 { get; set; }
        public float tmrees3 { get; set; }
        public string tmrfs0 { get; set; }
        public string tmrfs1 { get; set; }
        public string tmrfs2 { get; set; }
        public string tmrfs3 { get; set; }
        public string tmrph0 { get; set; }
        public string tmrph1 { get; set; }
        public string tmrph2 { get; set; }
        public string tmrph3 { get; set; }
        public int tmrsp0 { get; set; }
        public int tmrsp1 { get; set; }
        public int tmrsp2 { get; set; }
        public int tmrsp3 { get; set; }
        public int tmtsr0 { get; set; }
        public int tmtsr1 { get; set; }
        public int tmtsr2 { get; set; }
        public int tmtsr3 { get; set; }
        public string tmtss0 { get; set; }
        public string tmtss1 { get; set; }
        public string tmtss2 { get; set; }
        public string tmtss3 { get; set; }
        public float tmvds0 { get; set; }
        public float tmvds1 { get; set; }
        public float tmvds2 { get; set; }
        public float tmvds3 { get; set; }
        public int tmvhp0 { get; set; }
        public int tmvhp1 { get; set; }
        public int tmvhp2 { get; set; }
        public int tmvhp3 { get; set; }
        public int tnum { get; set; }
        public int todhr { get; set; }
        public int todmn { get; set; }
        public int tpas { get; set; }
        public int tprt { get; set; }
        public int tptb { get; set; }
        public int tptba { get; set; }
        public int tptbd { get; set; }
        public int trcmn00 { get; set; }
        public int trcmn01 { get; set; }
        public int trcmn02 { get; set; }
        public int trcmn03 { get; set; }
        public int trcmn10 { get; set; }
        public int trcmn11 { get; set; }
        public int trcmn12 { get; set; }
        public int trcmn13 { get; set; }
        public int trcmn20 { get; set; }
        public int trcmn21 { get; set; }
        public int trcmn22 { get; set; }
        public int trcmn23 { get; set; }
        public int trcmn30 { get; set; }
        public int trcmn31 { get; set; }
        public int trcmn32 { get; set; }
        public int trcmn33 { get; set; }
        public int trel { get; set; }
        public int trrt { get; set; }
        public int trsrl00 { get; set; }
        public int trsrl01 { get; set; }
        public int trsrl02 { get; set; }
        public int trsrl03 { get; set; }
        public int trsrl10 { get; set; }
        public int trsrl11 { get; set; }
        public int trsrl12 { get; set; }
        public int trsrl13 { get; set; }
        public int trsrl20 { get; set; }
        public int trsrl21 { get; set; }
        public int trsrl22 { get; set; }
        public int trsrl23 { get; set; }
        public int trsrl30 { get; set; }
        public int trsrl31 { get; set; }
        public int trsrl32 { get; set; }
        public int trsrl33 { get; set; }
        public Trstf00n0 trstf00n0 { get; set; }
        public Trstf00n1 trstf00n1 { get; set; }
        public Trstf00n2 trstf00n2 { get; set; }
        public Trstf00n3 trstf00n3 { get; set; }
        public Trstf01n0 trstf01n0 { get; set; }
        public Trstf01n1 trstf01n1 { get; set; }
        public Trstf01n2 trstf01n2 { get; set; }
        public Trstf01n3 trstf01n3 { get; set; }
        public Trstf02n0 trstf02n0 { get; set; }
        public Trstf02n1 trstf02n1 { get; set; }
        public Trstf02n2 trstf02n2 { get; set; }
        public Trstf02n3 trstf02n3 { get; set; }
        public Trstf03n0 trstf03n0 { get; set; }
        public Trstf03n1 trstf03n1 { get; set; }
        public Trstf03n2 trstf03n2 { get; set; }
        public Trstf03n3 trstf03n3 { get; set; }
        public Trstf10n0 trstf10n0 { get; set; }
        public Trstf10n1 trstf10n1 { get; set; }
        public Trstf10n2 trstf10n2 { get; set; }
        public Trstf10n3 trstf10n3 { get; set; }
        public Trstf11n0 trstf11n0 { get; set; }
        public Trstf11n1 trstf11n1 { get; set; }
        public Trstf11n2 trstf11n2 { get; set; }
        public Trstf11n3 trstf11n3 { get; set; }
        public Trstf12n0 trstf12n0 { get; set; }
        public Trstf12n1 trstf12n1 { get; set; }
        public Trstf12n2 trstf12n2 { get; set; }
        public Trstf12n3 trstf12n3 { get; set; }
        public Trstf13n0 trstf13n0 { get; set; }
        public Trstf13n1 trstf13n1 { get; set; }
        public Trstf13n2 trstf13n2 { get; set; }
        public Trstf13n3 trstf13n3 { get; set; }
        public Trstf20n0 trstf20n0 { get; set; }
        public Trstf20n1 trstf20n1 { get; set; }
        public Trstf20n2 trstf20n2 { get; set; }
        public Trstf20n3 trstf20n3 { get; set; }
        public Trstf21n0 trstf21n0 { get; set; }
        public Trstf21n1 trstf21n1 { get; set; }
        public Trstf21n2 trstf21n2 { get; set; }
        public Trstf21n3 trstf21n3 { get; set; }
        public Trstf22n0 trstf22n0 { get; set; }
        public Trstf22n1 trstf22n1 { get; set; }
        public Trstf22n2 trstf22n2 { get; set; }
        public Trstf22n3 trstf22n3 { get; set; }
        public Trstf23n0 trstf23n0 { get; set; }
        public Trstf23n1 trstf23n1 { get; set; }
        public Trstf23n2 trstf23n2 { get; set; }
        public Trstf23n3 trstf23n3 { get; set; }
        public Trstf30n0 trstf30n0 { get; set; }
        public Trstf30n1 trstf30n1 { get; set; }
        public Trstf30n2 trstf30n2 { get; set; }
        public Trstf30n3 trstf30n3 { get; set; }
        public Trstf31n0 trstf31n0 { get; set; }
        public Trstf31n1 trstf31n1 { get; set; }
        public Trstf31n2 trstf31n2 { get; set; }
        public Trstf31n3 trstf31n3 { get; set; }
        public Trstf32n0 trstf32n0 { get; set; }
        public Trstf32n1 trstf32n1 { get; set; }
        public Trstf32n2 trstf32n2 { get; set; }
        public Trstf32n3 trstf32n3 { get; set; }
        public Trstf33n0 trstf33n0 { get; set; }
        public Trstf33n1 trstf33n1 { get; set; }
        public Trstf33n2 trstf33n2 { get; set; }
        public Trstf33n3 trstf33n3 { get; set; }
        public float trsth00n0 { get; set; }
        public float trsth00n1 { get; set; }
        public float trsth00n2 { get; set; }
        public float trsth00n3 { get; set; }
        public float trsth01n0 { get; set; }
        public float trsth01n1 { get; set; }
        public float trsth01n2 { get; set; }
        public float trsth01n3 { get; set; }
        public float trsth02n0 { get; set; }
        public float trsth02n1 { get; set; }
        public float trsth02n2 { get; set; }
        public float trsth02n3 { get; set; }
        public float trsth03n0 { get; set; }
        public float trsth03n1 { get; set; }
        public float trsth03n2 { get; set; }
        public float trsth03n3 { get; set; }
        public float trsth10n0 { get; set; }
        public float trsth10n1 { get; set; }
        public float trsth10n2 { get; set; }
        public float trsth10n3 { get; set; }
        public float trsth11n0 { get; set; }
        public float trsth11n1 { get; set; }
        public float trsth11n2 { get; set; }
        public float trsth11n3 { get; set; }
        public float trsth12n0 { get; set; }
        public float trsth12n1 { get; set; }
        public float trsth12n2 { get; set; }
        public float trsth12n3 { get; set; }
        public float trsth13n0 { get; set; }
        public float trsth13n1 { get; set; }
        public float trsth13n2 { get; set; }
        public float trsth13n3 { get; set; }
        public float trsth20n0 { get; set; }
        public float trsth20n1 { get; set; }
        public float trsth20n2 { get; set; }
        public float trsth20n3 { get; set; }
        public float trsth21n0 { get; set; }
        public float trsth21n1 { get; set; }
        public float trsth21n2 { get; set; }
        public float trsth21n3 { get; set; }
        public float trsth22n0 { get; set; }
        public float trsth22n1 { get; set; }
        public float trsth22n2 { get; set; }
        public float trsth22n3 { get; set; }
        public float trsth23n0 { get; set; }
        public float trsth23n1 { get; set; }
        public float trsth23n2 { get; set; }
        public float trsth23n3 { get; set; }
        public float trsth30n0 { get; set; }
        public float trsth30n1 { get; set; }
        public float trsth30n2 { get; set; }
        public float trsth30n3 { get; set; }
        public float trsth31n0 { get; set; }
        public float trsth31n1 { get; set; }
        public float trsth31n2 { get; set; }
        public float trsth31n3 { get; set; }
        public float trsth32n0 { get; set; }
        public float trsth32n1 { get; set; }
        public float trsth32n2 { get; set; }
        public float trsth32n3 { get; set; }
        public float trsth33n0 { get; set; }
        public float trsth33n1 { get; set; }
        public float trsth33n2 { get; set; }
        public float trsth33n3 { get; set; }
        public Trstp00n0 trstp00n0 { get; set; }
        public Trstp00n1 trstp00n1 { get; set; }
        public Trstp00n2 trstp00n2 { get; set; }
        public Trstp00n3 trstp00n3 { get; set; }
        public Trstp01n0 trstp01n0 { get; set; }
        public Trstp01n1 trstp01n1 { get; set; }
        public Trstp01n2 trstp01n2 { get; set; }
        public Trstp01n3 trstp01n3 { get; set; }
        public Trstp02n0 trstp02n0 { get; set; }
        public Trstp02n1 trstp02n1 { get; set; }
        public Trstp02n2 trstp02n2 { get; set; }
        public Trstp02n3 trstp02n3 { get; set; }
        public Trstp03n0 trstp03n0 { get; set; }
        public Trstp03n1 trstp03n1 { get; set; }
        public Trstp03n2 trstp03n2 { get; set; }
        public Trstp03n3 trstp03n3 { get; set; }
        public Trstp10n0 trstp10n0 { get; set; }
        public Trstp10n1 trstp10n1 { get; set; }
        public Trstp10n2 trstp10n2 { get; set; }
        public Trstp10n3 trstp10n3 { get; set; }
        public Trstp11n0 trstp11n0 { get; set; }
        public Trstp11n1 trstp11n1 { get; set; }
        public Trstp11n2 trstp11n2 { get; set; }
        public Trstp11n3 trstp11n3 { get; set; }
        public Trstp12n0 trstp12n0 { get; set; }
        public Trstp12n1 trstp12n1 { get; set; }
        public Trstp12n2 trstp12n2 { get; set; }
        public Trstp12n3 trstp12n3 { get; set; }
        public Trstp13n0 trstp13n0 { get; set; }
        public Trstp13n1 trstp13n1 { get; set; }
        public Trstp13n2 trstp13n2 { get; set; }
        public Trstp13n3 trstp13n3 { get; set; }
        public Trstp20n0 trstp20n0 { get; set; }
        public Trstp20n1 trstp20n1 { get; set; }
        public Trstp20n2 trstp20n2 { get; set; }
        public Trstp20n3 trstp20n3 { get; set; }
        public Trstp21n0 trstp21n0 { get; set; }
        public Trstp21n1 trstp21n1 { get; set; }
        public Trstp21n2 trstp21n2 { get; set; }
        public Trstp21n3 trstp21n3 { get; set; }
        public Trstp22n0 trstp22n0 { get; set; }
        public Trstp22n1 trstp22n1 { get; set; }
        public Trstp22n2 trstp22n2 { get; set; }
        public Trstp22n3 trstp22n3 { get; set; }
        public Trstp23n0 trstp23n0 { get; set; }
        public Trstp23n1 trstp23n1 { get; set; }
        public Trstp23n2 trstp23n2 { get; set; }
        public Trstp23n3 trstp23n3 { get; set; }
        public Trstp30n0 trstp30n0 { get; set; }
        public Trstp30n1 trstp30n1 { get; set; }
        public Trstp30n2 trstp30n2 { get; set; }
        public Trstp30n3 trstp30n3 { get; set; }
        public Trstp31n0 trstp31n0 { get; set; }
        public Trstp31n1 trstp31n1 { get; set; }
        public Trstp31n2 trstp31n2 { get; set; }
        public Trstp31n3 trstp31n3 { get; set; }
        public Trstp32n0 trstp32n0 { get; set; }
        public Trstp32n1 trstp32n1 { get; set; }
        public Trstp32n2 trstp32n2 { get; set; }
        public Trstp32n3 trstp32n3 { get; set; }
        public Trstp33n0 trstp33n0 { get; set; }
        public Trstp33n1 trstp33n1 { get; set; }
        public Trstp33n2 trstp33n2 { get; set; }
        public Trstp33n3 trstp33n3 { get; set; }
        public float tsc3 { get; set; }
        public float tsc4 { get; set; }
        public float tscfov { get; set; }
        public float tscfov1 { get; set; }
        public float tscfov2 { get; set; }
        public float tscfov3 { get; set; }
        public Tscpos tscpos { get; set; }
        public Tscpos1 tscpos1 { get; set; }
        public Tscpos2 tscpos2 { get; set; }
        public Tscpos3 tscpos3 { get; set; }
        public Tscrot tscrot { get; set; }
        public Tscrot1 tscrot1 { get; set; }
        public Tscrot2 tscrot2 { get; set; }
        public Tscrot3 tscrot3 { get; set; }
        public int tshd { get; set; }
        public float tshead { get; set; }
        public float tshead1 { get; set; }
        public float tshead2 { get; set; }
        public float tshead3 { get; set; }
        public Tspos tspos { get; set; }
        public Tspos1 tspos1 { get; set; }
        public Tspos2 tspos2 { get; set; }
        public Tspos3 tspos3 { get; set; }
        public int tstrm { get; set; }
        public int tswpal0 { get; set; }
        public int tswpal1 { get; set; }
        public int tswpal2 { get; set; }
        public int tswpal3 { get; set; }
        public float turammo { get; set; }
        public int turgudm { get; set; }
        public int tvnc0 { get; set; }
        public int tvnc1 { get; set; }
        public int tvnc2 { get; set; }
        public int tvnc3 { get; set; }
        public int tvpm0 { get; set; }
        public int tvpm1 { get; set; }
        public int tvpm2 { get; set; }
        public int tvpm3 { get; set; }
        public int twcdi { get; set; }
        public int twcon { get; set; }
        public int twct1 { get; set; }
        public int twct2 { get; set; }
        public int twct3 { get; set; }
        public int twct4 { get; set; }
        public int twcto { get; set; }
        public int twcun { get; set; }
        public float twdas { get; set; }
        public int twpta { get; set; }
        public int twrst { get; set; }
        public int twti { get; set; }
        public int type { get; set; }
        public Vcpr vcpr { get; set; }
        public int vdt { get; set; }
        public int vifcit0 { get; set; }
        public int vifcit1 { get; set; }
        public int vifcit2 { get; set; }
        public int vifcit3 { get; set; }
        public int vrsp { get; set; }
        public int vsbsout { get; set; }
        public int vsclout { get; set; }
        public int vsdfstc { get; set; }
        public int vsenout { get; set; }
        public int vshwout { get; set; }
        public int vstgout { get; set; }
        public int vsthout { get; set; }
        public int vstm { get; set; }
        public Vtwsp vtwsp { get; set; }
        public Vtwsr vtwsr { get; set; }
        public float vwfdt { get; set; }
        public int vwmgda { get; set; }
        public int vwmgfr { get; set; }
        public int vwmgnb { get; set; }
        public int vwp0 { get; set; }
        public int vwp1 { get; set; }
        public int vwp15 { get; set; }
        public int vwp16 { get; set; }
        public int vwp2 { get; set; }
        public int vwp3 { get; set; }
        public int vwp4 { get; set; }
        public int vwp5 { get; set; }
        public int vwpbhd { get; set; }
        public int vwprbs { get; set; }
        public int wrploc { get; set; }
        public int wvmarc { get; set; }
        public int wvmdsr { get; set; }
        public int wvmsber { get; set; }
        public int wvmsbet { get; set; }
        public int xpr { get; set; }
    }

    public class Apart
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Area
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Atscmp
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Atscmr
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Atspos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cam
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Camf
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Camfr
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Camo
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Camro
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i0s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i0s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i0s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i0s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i1s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i1s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i1s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i1s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i2s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i2s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i2s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i2s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i3s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i3s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i3s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i3s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i4s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i4s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i4s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv0i4s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i0s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i0s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i0s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i0s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i1s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i1s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i1s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i1s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i2s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i2s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i2s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i2s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i3s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i3s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i3s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i3s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i4s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i4s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i4s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv1i4s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i0s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i0s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i0s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i0s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i1s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i1s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i1s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i1s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i2s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i2s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i2s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i2s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i3s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i3s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i3s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i3s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i4s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i4s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i4s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv2i4s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i0s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i0s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i0s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i0s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i1s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i1s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i1s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i1s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i2s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i2s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i2s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i2s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i3s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i3s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i3s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i3s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i4s0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i4s1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i4s2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpv3i4s3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ecscp
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ecscs
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr5
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr6
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr7
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr8
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclr9
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv5
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv6
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv7
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv8
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Fsclv9
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Phpo
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpoi0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpoi1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpoi2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpoi3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpos0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpos1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpos2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pmpos3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspcc0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspcc1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspcc2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspcc3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspcc4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspco0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspco1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspco2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspco3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rmspco4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos10
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos11
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos12
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos13
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos14
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos15
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos16
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos17
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos18
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos19
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos5
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos6
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos7
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos8
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rzpos9
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ssdsp
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Start
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf00n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf00n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf00n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf00n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf01n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf01n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf01n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf01n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf02n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf02n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf02n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf02n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf03n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf03n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf03n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf03n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf10n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf10n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf10n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf10n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf11n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf11n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf11n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf11n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf12n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf12n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf12n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf12n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf13n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf13n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf13n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf13n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf20n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf20n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf20n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf20n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf21n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf21n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf21n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf21n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf22n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf22n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf22n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf22n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf23n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf23n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf23n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf23n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf30n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf30n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf30n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf30n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf31n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf31n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf31n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf31n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf32n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf32n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf32n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf32n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf33n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf33n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf33n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstf33n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp00n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp00n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp00n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp00n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp01n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp01n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp01n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp01n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp02n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp02n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp02n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp02n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp03n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp03n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp03n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp03n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp10n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp10n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp10n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp10n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp11n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp11n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp11n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp11n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp12n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp12n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp12n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp12n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp13n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp13n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp13n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp13n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp20n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp20n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp20n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp20n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp21n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp21n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp21n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp21n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp22n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp22n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp22n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp22n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp23n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp23n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp23n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp23n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp30n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp30n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp30n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp30n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp31n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp31n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp31n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp31n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp32n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp32n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp32n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp32n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp33n0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp33n1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp33n2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Trstp33n3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscpos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscpos1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscpos2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscpos3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscrot
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscrot1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscrot2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tscrot3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tspos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tspos1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tspos2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Tspos3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vcpr
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vtwsp
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vtwsr
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Obj
    {
        public object[] SMeR { get; set; }
        public object[] ammoforwep { get; set; }
        public object[] bits { get; set; }
        public object[] bits2 { get; set; }
        public object[] bits3 { get; set; }
        public object[] cont { get; set; }
        public object[] cpup { get; set; }
        public object[] cpupr { get; set; }
        public object[] cpupt { get; set; }
        public object[] dspn { get; set; }
        public object[] gotor { get; set; }
        public object[] head { get; set; }
        public object[] hlt { get; set; }
        public object[] inco { get; set; }
        public object[] inhsh { get; set; }
        public object[] iobjhbir { get; set; }
        public object[] iobjhbor { get; set; }
        public object[] loc { get; set; }
        public object[] mgDT { get; set; }
        public object[] mgbs { get; set; }
        public object[] model { get; set; }
        public object[] nmfail { get; set; }
        public object[] nmpass { get; set; }
        public int no { get; set; }
        public object[] o2sh { get; set; }
        public object[] o2sp { get; set; }
        public object[] oIntAnim { get; set; }
        public object[] oIntPed { get; set; }
        public object[] obb { get; set; }
        public object[] obbc { get; set; }
        public object[] obbs { get; set; }
        public object[] obcra { get; set; }
        public object[] obder { get; set; }
        public object[] obint { get; set; }
        public object[] objLOD { get; set; }
        public object[] objap { get; set; }
        public object[] objapt { get; set; }
        public object[] objaro { get; set; }
        public object[] objatto { get; set; }
        public object[] objbr { get; set; }
        public object[] objbtte { get; set; }
        public object[] objclt { get; set; }
        public object[] objcnm { get; set; }
        public object[] objcps { get; set; }
        public object[] objcr { get; set; }
        public object[] objct { get; set; }
        public object[] objct2 { get; set; }
        public object[] objct3 { get; set; }
        public object[] objct4 { get; set; }
        public object[] objhpovr { get; set; }
        public object[] objinv { get; set; }
        public object[] objtvi { get; set; }
        public object[] obrmr { get; set; }
        public object[] obrom { get; set; }
        public object[] obrr { get; set; }
        public object[] obso { get; set; }
        public object[] obtc { get; set; }
        public object[] obtcsr { get; set; }
        public object[] obtcta { get; set; }
        public object[] obtcts { get; set; }
        public object[] obtcvr { get; set; }
        public object[] obtcvw { get; set; }
        public object[] obtcwt { get; set; }
        public object[] oiet { get; set; }
        public object[] oijh { get; set; }
        public object[] omcf { get; set; }
        public object[] omcp { get; set; }
        public object[] orbcnno { get; set; }
        public object[] ororc { get; set; }
        public object[] osgr { get; set; }
        public object[] osnei { get; set; }
        public object[] osnt { get; set; }
        public object[] ospdl { get; set; }
        public object[] ospl { get; set; }
        public object[] ossgr { get; set; }
        public int pal { get; set; }
        public object[] ped { get; set; }
        public object[] rot { get; set; }
        public object[] rsp { get; set; }
        public object[] rsprd { get; set; }
        public int rtm { get; set; }
        public object[] spwn { get; set; }
        public object[] spwn2 { get; set; }
        public object[] spwn3 { get; set; }
        public object[] spwn4 { get; set; }
        public object[] stg { get; set; }
        public object[] team { get; set; }
        public object[] team2 { get; set; }
        public object[] team3 { get; set; }
        public object[] team4 { get; set; }
        public object[] tl63vts { get; set; }
        public object[] valu { get; set; }
        public object[] vehpu { get; set; }
    }

    public class Otzone
    {
        public object[] otbs { get; set; }
        public object[] otpg { get; set; }
        public object[] otpl { get; set; }
        public object[] otrw { get; set; }
        public object[] otvo { get; set; }
        public object[] otvt { get; set; }
        public int otz { get; set; }
    }

    public class PropData
    {
        public float[] TTPH { get; set; }
        public float[] TrPPD { get; set; }
        public int[] TrTAct { get; set; }
        public int[] aldel { get; set; }
        public int[] alsnd { get; set; }
        public int[] alteam { get; set; }
        public int[] asso { get; set; }
        public int[] asso2 { get; set; }
        public int[] asso3 { get; set; }
        public int[] asso4 { get; set; }
        public int[] asss { get; set; }
        public int[] asss2 { get; set; }
        public int[] asss3 { get; set; }
        public int[] asss4 { get; set; }
        public int[] asst { get; set; }
        public int[] asst2 { get; set; }
        public int[] asst3 { get; set; }
        public int[] asst4 { get; set; }
        public bool[] bpbid { get; set; } // id = is dynamic?
        public bool[] bpbip { get; set; }
        public int[] bpbpt { get; set; }
        public object[] cmodel { get; set; }
        public int[] fcuat { get; set; }
        public int[] flcl { get; set; }
        public int[] flvfx { get; set; }
        public Fwtpos[] fwTPos { get; set; }
        public float[] fwTSize { get; set; }
        public int[] fwTeam { get; set; }

        [JsonProperty("head")]
        public float[] Heading { get; set; }

        [JsonProperty("loc")]
        public Loc2[] Location { get; set; }

        [JsonProperty("model")]
        public int[] ModelName { get; set; }

        [JsonProperty("no")]
        public int Total { get; set; }
        public int noC { get; set; }

        [JsonProperty("pLODDist")]
        public int[] LODDistance { get; set; }
        public int[] pasc { get; set; }
        public int[] pasc2 { get; set; }
        public int[] pasc3 { get; set; }
        public int[] pasc4 { get; set; }
        public int[] pdip { get; set; }
        public int[] pprst { get; set; }
        public int[] prcra { get; set; }
        public int[] prpasn { get; set; }
        public int[] prpatn { get; set; }
        public int[] prpbs { get; set; }
        public int[] prpbs2 { get; set; }
        public int[] prpcl { get; set; }
        public int[] prpclc { get; set; }
        public int[] prpclcr { get; set; }

        [JsonProperty("prpclr")]
        public int[] PropVariation { get; set; }
        public int[] prpcr { get; set; }
        public int[] prpct { get; set; }
        public int[] prpdypil { get; set; }
        public int[] prplod { get; set; }
        public int[] prpsba { get; set; }
        public int[] prpsdp0 { get; set; }
        public int[] prpsdp1 { get; set; }
        public int[] prpsdp2 { get; set; }
        public int[] prpsdp3 { get; set; }
        public int[] prpsnpp { get; set; }
        public float[] prptds { get; set; }
        public float[] prptsp { get; set; }
        public int[] prrorc { get; set; }
        public int[] ptfxst { get; set; }
        public float[] ptfxtr { get; set; }
        public int[] sndid { get; set; }
        public int[] sndlmt { get; set; }
        public int[] sndtri { get; set; }
        public float[] updatez { get; set; }
        public int[] upddel { get; set; }
        public int[] updtime { get; set; }

        [JsonProperty("vRot")]
        public Vrot1[] Rotation { get; set; }
    }

    public class Fwtpos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Loc2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vrot1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptemp
    {
        public int no { get; set; }
        public int[] ptc0 { get; set; }
        public int[] ptc1 { get; set; }
        public int[] ptc2 { get; set; }
        public int[] ptc3 { get; set; }
        public int[] ptc4 { get; set; }
        public int[] ptc5 { get; set; }
        public int[] ptc6 { get; set; }
        public int[] ptc7 { get; set; }
        public int[] ptc8 { get; set; }
        public int[] ptc9 { get; set; }
        public int[] ptm0 { get; set; }
        public int[] ptm1 { get; set; }
        public int[] ptm2 { get; set; }
        public int[] ptm3 { get; set; }
        public int[] ptm4 { get; set; }
        public int[] ptm5 { get; set; }
        public int[] ptm6 { get; set; }
        public int[] ptm7 { get; set; }
        public int[] ptm8 { get; set; }
        public int[] ptm9 { get; set; }
        public Pto0[] pto0 { get; set; }
        public Pto1[] pto1 { get; set; }
        public Pto2[] pto2 { get; set; }
        public Pto3[] pto3 { get; set; }
        public Pto4[] pto4 { get; set; }
        public Pto5[] pto5 { get; set; }
        public Pto6[] pto6 { get; set; }
        public Pto7[] pto7 { get; set; }
        public Pto8[] pto8 { get; set; }
        public Pto9[] pto9 { get; set; }
        public Ptr0[] ptr0 { get; set; }
        public Ptr1[] ptr1 { get; set; }
        public Ptr2[] ptr2 { get; set; }
        public Ptr3[] ptr3 { get; set; }
        public Ptr4[] ptr4 { get; set; }
        public Ptr5[] ptr5 { get; set; }
        public Ptr6[] ptr6 { get; set; }
        public Ptr7[] ptr7 { get; set; }
        public Ptr8[] ptr8 { get; set; }
        public Ptr9[] ptr9 { get; set; }
    }

    public class Pto0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto5
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto6
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto7
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto8
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Pto9
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr5
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr6
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr7
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr8
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Ptr9
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Race
    {
        public int[] adlc { get; set; }
        public int[] adlc2 { get; set; }
        public int[] aveh { get; set; }
        public int bsted { get; set; }
        public int btfs0 { get; set; }
        public int btfs1 { get; set; }
        public int btfs10 { get; set; }
        public int btfs11 { get; set; }
        public int btfs2 { get; set; }
        public int btfs3 { get; set; }
        public int btfs4 { get; set; }
        public int btfs5 { get; set; }
        public int btfs6 { get; set; }
        public int btfs7 { get; set; }
        public int btfs8 { get; set; }
        public int btfs9 { get; set; }
        public int cemn { get; set; }
        public int cemx { get; set; }
        public int[] chdlo { get; set; }
        public int[] chdlos { get; set; }

        [JsonProperty("chh")]
        public float[] CheckpointHeadings { get; set; }

        [JsonProperty("chl")]
        public Chl[] CheckpointLocations { get; set; }

        [JsonProperty("chp")]
        public int CheckpointTotal { get; set; }
        public float[] chpp { get; set; }
        public float[] chpps { get; set; }

        [JsonProperty("chs")]
        public float[] CheckpointScale { get; set; }
        public float[] chs2 { get; set; }
        public int[] chsto { get; set; }
        public int[] chstos { get; set; }
        public int[] chttr { get; set; }
        public int[] chttu { get; set; }
        public float[] chvs { get; set; }
        public int clbs { get; set; }
        public Cpado[] cpado { get; set; }
        public Cpado1[] cpados { get; set; }
        public int[] cpbs1 { get; set; }
        public int[] cpbs2 { get; set; }
        public int[] cppsst { get; set; }
        public int[] cptfrm { get; set; }
        public int[] cptfrms { get; set; }
        public int[] cpwwt { get; set; }
        public float gl { get; set; }

        [JsonProperty("grid")]
        public Grid GridLocation { get; set; }

        [JsonProperty("gridty")]
        public int GridType { get; set; }
        public int gtar { get; set; }
        public float gw { get; set; }

        [JsonProperty("head")]
        public float GridHeading { get; set; } // some sort of heading but for what? Starting line?
        public string icpht0 { get; set; }
        public string icpht1 { get; set; }
        public string icpht2 { get; set; }
        public int icv { get; set; }
        public bool iprem { get; set; }

        [JsonProperty("lanes")]
        public int GridLanes { get; set; } // probably

        [JsonProperty("lap")]
        public int NumberOfLaps { get; set; }
        public float lrgs { get; set; }
        public int ptp { get; set; }
        public int rcdam { get; set; }

        [JsonProperty("rdis")]
        public float RaceDistance { get; set; }
        public int retl { get; set; }
        public Scene scene { get; set; }
        public int sgdo { get; set; }
        [JsonProperty("sndchk")]
        public Sndchk[] SecondaryCheckPointPositions { get; set; } // "sound check" but for what? they are location vectors
        public float[] sndrsp { get; set; }
        public int strtg { get; set; }
        public int subtype { get; set; }
        public int trbpc0 { get; set; }
        public int trbpc1 { get; set; }
        public int trbpc2 { get; set; }
        public int trbpf0 { get; set; }
        public int trbpf1 { get; set; }
        public int trbpf2 { get; set; }
        public int trbpf3 { get; set; }
        public int trbpf4 { get; set; }
        public int trbpf5 { get; set; }
        public int trbpf6 { get; set; }
        public int trbpf7 { get; set; }
        public int trbpf8 { get; set; }
        public int trbpf9 { get; set; }
        public int trbps0d0 { get; set; }
        public int trbps0d1 { get; set; }
        public int trbps0d2 { get; set; }
        public int trbps1d0 { get; set; }
        public int trbps1d1 { get; set; }
        public int trbps1d2 { get; set; }
        public int trbps2d0 { get; set; }
        public int trbps2d1 { get; set; }
        public int trbps2d2 { get; set; }
        public int trbps3d0 { get; set; }
        public int trbps3d1 { get; set; }
        public int trbps3d2 { get; set; }
        public int[] trfmvm { get; set; }
        public int tri1 { get; set; }
        public int tri2 { get; set; }

        [JsonProperty("type")]
        public int RaceType { get; set; }
        public float udgs { get; set; }

        [JsonProperty("vspn0")]
        public Vspn0[] VehicleSpawnsZero { get; set; } // vehicle spawns?

        [JsonProperty("vspn1")]
        public Vspn1[] VehicleSpawnsOne { get; set; }
        [JsonProperty("vspn2")]
        public Vspn2[] VehicleSpawnsTwo { get; set; }

        [JsonProperty("vspns0")]
        public Vspns0[] vspns0 { get; set; } // also more spawns? "secondary" spawns?
        public Vspns1[] vspns1 { get; set; }
        public Vspns2[] vspns2 { get; set; }
        public int[] vta { get; set; }
    }

    public class Grid
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Scene
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Chl
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpado
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Cpado1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Sndchk
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vspn0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vspn1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vspn2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vspns0
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vspns1
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vspns2
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rule
    {
        public int aim { get; set; } // enable auto aim?
        public int apeds { get; set; } // ped population?
        public int blip { get; set; } // show blips?

        public int liv { get; set; } // lives or livery?
        public int pol { get; set; }
        public int prule { get; set; }
        public int ptyp { get; set; }

        [JsonProperty("radio")]
        public int RadioStation { get; set; }

        [JsonProperty("score")]
        public int ShowScores { get; set; }

        [JsonProperty("tag")]
        public int ShowGamertags { get; set; }

        [JsonProperty("tdm")]
        public int IsTeamMatch { get; set; }
        public int time { get; set; } // set time?

        [JsonProperty("tod")]
        public int TimeOfDay { get; set; }

        [JsonProperty("traf")]
        public int EnabledTraffic { get; set; }

        [JsonProperty("vdm")]
        public int AllowVehicleCollisions { get; set; }

        [JsonProperty("vehd")]
        public int DestroyLastPlace { get; set; }

        [JsonProperty("voice")]
        public int EnableVoice { get; set; }

        public int weth { get; set; } // weather?
    }

    public class Usj
    {
        public int no { get; set; }
        public object[] vcm { get; set; }
        public object[] vld { get; set; }
        public object[] vto { get; set; }
    }

    public class Veh
    {
        public object[] bdyhp { get; set; }
        public int burst { get; set; }
        public object[] cbves { get; set; }
        public object[] cbvest { get; set; }
        public object[] cdtor { get; set; }
        public int[] col { get; set; }
        public object[] col2 { get; set; }
        public object[] col3 { get; set; }
        public object[] colc { get; set; }
        public object[] crgdm { get; set; }
        public object[] cutsc { get; set; }
        public object[] cutsh { get; set; }
        public object[] cvd { get; set; }
        public int[] drbs { get; set; }
        public object[] enghp { get; set; }
        public object[] enveff { get; set; }
        public object[] fdswm { get; set; }
        public object[] frsth { get; set; }
        public object[] frsth1 { get; set; }
        public object[] frsth2 { get; set; }
        public object[] frsth3 { get; set; }
        public object[] gotor { get; set; }
        public object[] hbir { get; set; }
        public object[] hbor { get; set; }

        [JsonProperty("head")]
        public float[] Heading { get; set; }

        [JsonProperty("hlth")]
        public int[] Health { get; set; }
        public object[] hmrh { get; set; }
        public object[] htrh { get; set; }
        public object[] hvcr { get; set; }
        public object[] ior { get; set; }
        public object[] iort { get; set; }
        public object[] irsth { get; set; }
        public object[] irsth1 { get; set; }
        public object[] irsth2 { get; set; }
        public object[] irsth3 { get; set; }

        [JsonProperty("liv")]
        public int[] Livery { get; set; }

        [JsonProperty("loc")]
        public Loc3[] Locations { get; set; }

        [JsonProperty("model")]
        public int[] ModelHash { get; set; }
        public object[] modps { get; set; }
        public object[] ncol { get; set; }
        public object[] nmfail { get; set; }
        public object[] nmpass { get; set; }

        [JsonProperty("no")]
        public int Total { get; set; }
        public object[] objt { get; set; }
        public object[] objt2 { get; set; }
        public object[] objt3 { get; set; }
        public object[] objt4 { get; set; }
        public int pal { get; set; }
        public object[] ptrhp { get; set; }

        [JsonProperty("rot")]
        public Rot[] Rotation { get; set; }
        public int[] rsp { get; set; }
        public object[] spwn { get; set; }
        public object[] spwn2 { get; set; }
        public object[] spwn3 { get; set; }
        public object[] spwn4 { get; set; }
        public object[] team { get; set; }
        public object[] team2 { get; set; }
        public object[] team3 { get; set; }
        public object[] team4 { get; set; }
        public int time { get; set; }
        public object[] ubrkdb { get; set; }
        public object[] v2sh { get; set; }
        public object[] v2si { get; set; }
        public object[] v2sp { get; set; }
        public int[] vbs2 { get; set; }
        public int[] vbs3 { get; set; }
        public int[] vbs4 { get; set; }
        public int[] vbs5 { get; set; }
        public int[] vbs6 { get; set; }
        public int[] vbs7 { get; set; }
        public int[] vbs8 { get; set; }
        public object[] vbvrr0 { get; set; }
        public object[] vbvrr1 { get; set; }
        public object[] vbvrr10 { get; set; }
        public object[] vbvrr11 { get; set; }
        public object[] vbvrr12 { get; set; }
        public object[] vbvrr13 { get; set; }
        public object[] vbvrr14 { get; set; }
        public object[] vbvrr15 { get; set; }
        public object[] vbvrr16 { get; set; }
        public object[] vbvrr2 { get; set; }
        public object[] vbvrr3 { get; set; }
        public object[] vbvrr4 { get; set; }
        public object[] vbvrr5 { get; set; }
        public object[] vbvrr6 { get; set; }
        public object[] vbvrr7 { get; set; }
        public object[] vbvrr8 { get; set; }
        public object[] vbvrr9 { get; set; }
        public object[] vcnm { get; set; }
        public object[] vdInter { get; set; }
        public object[] vdcbal { get; set; }
        public object[] vdcbdt { get; set; }
        public object[] vddfs { get; set; }
        public object[] vddra { get; set; }
        public object[] vddrl { get; set; }
        public object[] vddta { get; set; }
        public object[] vddwda { get; set; }
        public object[] vdeitc { get; set; }
        public object[] vdrpovr { get; set; }
        public object[] vdspn { get; set; }
        public object[] vdvrfe { get; set; }
        public object[] vebs { get; set; }
        public object[] vehakwlrt { get; set; }
        public object[] vehap { get; set; }
        public object[] vehat { get; set; }
        public object[] vehbc { get; set; }
        public object[] vehbr { get; set; }
        public object[] vehbrnlf { get; set; }
        public object[] vehbrnrl { get; set; }
        public object[] vehbrntm { get; set; }
        public object[] vehbs { get; set; }
        public object[] vehbso { get; set; }
        public object[] vehbtos { get; set; }
        public object[] vehcr { get; set; }
        public object[] vehct { get; set; }
        public object[] vehcv { get; set; }
        public object[] vehdelind { get; set; }
        public object[] vehdu { get; set; }
        public object[] vehfbd { get; set; }
        public object[] vehfbr { get; set; }
        public object[] vehpotme { get; set; }
        public object[] vehtc { get; set; }
        public object[] vehwtci { get; set; }
        public object[] vhcra { get; set; }
        public object[] viclv { get; set; }
        public object[] vifci { get; set; }
        public object[] vldr { get; set; }
        public object[] vldt { get; set; }
        public object[] vldv { get; set; }
        public object[] vmcf { get; set; }
        public object[] vmcp { get; set; }
        public int[] vmodBomb { get; set; }
        public int[] vmodairc { get; set; }
        public int[] vmodarm { get; set; }
        public int[] vmodspoil { get; set; }
        public int[] vmodtur { get; set; }
        public object[] vphrang { get; set; }
        public object[] vrhlor { get; set; }
        public object[] vrmr { get; set; }
        public object[] vrorc { get; set; }
        public object[] vrr { get; set; }
        public object[] vrrd { get; set; }
        public object[] vrstp { get; set; }
        public object[] vrstp1 { get; set; }
        public object[] vrstp2 { get; set; }
        public object[] vrstp3 { get; set; }
        public object[] vsgr { get; set; }
        public object[] vsnei { get; set; }
        public object[] vsnt { get; set; }
        public object[] vspdl { get; set; }
        public object[] vssgr { get; set; }
        public object[] vtmhrn { get; set; }
        public object[] vtspr { get; set; }
        public object[] vtsr { get; set; }
        public object[] vwpndmg { get; set; }
    }

    public class Loc3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Rot
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Vhrls
    {
    }

    public class Weap
    {
        public object[] bits { get; set; }

        [JsonProperty("blip")]
        public int BlipType { get; set; }
        public object[] brest1 { get; set; }
        public object[] brest2 { get; set; }
        public object[] brest3 { get; set; }
        public object[] brest4 { get; set; }
        public object[] clip { get; set; }

        [JsonProperty("dmgmult")]
        public object[] DamageMultiplier { get; set; }

        [JsonProperty("head")]
        public object[] Heading { get; set; }
        public object[] ipdi { get; set; }
        public object[] iptnp { get; set; }
        public object[] iwati { get; set; }

        [JsonProperty("loc")]
        public object[] Locations { get; set; }

        [JsonProperty("no")]
        public int Total { get; set; }
        public int pal { get; set; }
        public bool randtyp { get; set; }

        [JsonProperty("rotx")]
        public object[] RotationX { get; set; }

        [JsonProperty("roty")]
        public object[] RotationY { get; set; }
        public object[] rput { get; set; }
        public object[] sub { get; set; }
        public int time { get; set; }

        [JsonProperty("type")]
        public object[] WeaponHashes { get; set; }
        public object[] vasso { get; set; }
        public object[] vasso2 { get; set; }
        public object[] vasso3 { get; set; }
        public object[] vasso4 { get; set; }
        public object[] vasss { get; set; }
        public object[] vasss2 { get; set; }
        public object[] vasss3 { get; set; }
        public object[] vasss4 { get; set; }
        public object[] vasst { get; set; }
        public object[] vasst2 { get; set; }
        public object[] vasst3 { get; set; }
        public object[] vasst4 { get; set; }
        public object[] vbmbl { get; set; }
        public object[] vbmbm { get; set; }
        public object[] vclnr { get; set; }
        public object[] vclnrl { get; set; }
        public object[] vclnt { get; set; }
        public object[] vput { get; set; }
        public object[] wspg { get; set; }
        public object[] wsspg { get; set; }
    }

    public class Zone
    {
        public int no { get; set; }
        public object[] vld { get; set; }
        public object[] vto { get; set; }
        public object[] znatp { get; set; }
        public object[] znbs { get; set; }
        public object[] zndel { get; set; }
        public object[] znepr0 { get; set; }
        public object[] znepr1 { get; set; }
        public object[] znepr2 { get; set; }
        public object[] znepr3 { get; set; }
        public object[] zngPo { get; set; }
        public object[] zngTe { get; set; }
        public object[] znhei { get; set; }
        public object[] znpr0 { get; set; }
        public object[] znpr1 { get; set; }
        public object[] znpr2 { get; set; }
        public object[] znpr3 { get; set; }
        public object[] zntp { get; set; }
        public object[] znwd { get; set; }
        public object[] znwid { get; set; }
        public object[] znwvd { get; set; }
    }
}