// [AUTO_HEADER]

#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <sstream>
#include "OVBenchmark.h"
#include "OVStringHelper.h"
#include "OVUTF8Helper.h"
#include "OVWildcard.h"
#include "Mandarin.h"

using namespace OpenVanilla;
using namespace Formosa::Mandarin;
using namespace std;

int main()
{
    OVWildcard chardef("%chardef", '?', '*', false);
    
    string line;
    while(!cin.eof()) {
        getline(cin, line);
        cout << line << endl;
        
        if (chardef.match(line)) {
            while(!cin.eof()) {
                getline(cin, line);
                if (chardef.match(line)) {
                    cout << line << endl;
                    break;
                }
                
                vector<string> vec = OVStringHelper::SplitBySpacesOrTabs(line);
                const BopomofoKeyboardLayout* layout = BopomofoKeyboardLayout::StandardLayout();
                
                BPMF bpmf = layout->syllableFromKeySequence(vec[0]);
                cout << bpmf.absoluteOrderString() << " " << vec[1] << endl;
            }
        }
    }
    
    return 0;
}