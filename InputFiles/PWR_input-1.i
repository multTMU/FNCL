FNCL calib 15 g/cm
c Originally by A.Tomanin 
c modified by T.H.Lee (Nov.2015) with multiple universes
c modified by J. Beaumont (2016-2017)
c modified by M. Root (2021)
c Run in MCNPX-Polimi
c Analyze output .d file with modified SimPlis post-processor
c model accounts for AmLi neutrons and subsequent induced fission neutrons and gammas only 
c this corresponds to the net neutron doubles (active-passive) measurement 
c ------------------------------------------------------------- c
1    20 -10.41      -20         u=1  imp:n,p=1  $ 1.13% enr. sample
2    5  -0.001293   -21  20     u=1  imp:n,p=1  $ air                 
3    15 -6.56       -22  21     u=1  imp:n,p=1  $ Zr cladding                  
4    5  -0.001293    22         u=1  imp:n,p=1  $ air   
c                                     
5    like 1 but   mat=20  RHO=-10.41    u=2  $ 5% enr. sample
6    like 2 but                 u=2               $ air                                     
7    like 3 but                 u=2               $ Zr cladding                             
8    like 4 but                 u=2               $ air        
c
c                                                                                       
c
20   5  -0.001293   -25         u=8  imp:n,p=1  $ air    
21   15 -6.56       -26  25     u=8  imp:n,p=1  $ Zr Guide tube     
22   5  -0.001293    26         u=8  imp:n,p=1  $ air                     
c
25    0    -27  lat=1  fill=-8:8  -8:8  0:0 
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2                                       
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2
        2 2 2 2 2  8 2 2 8 2 2 8  2 2 2 2 2 
        2 2 2 8 2  2 2 2 2 2 2 2  2 8 2 2 2 
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2
        2 2 8 2 2  8 2 2 8 2 2 8  2 2 8 2 2 
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2                                       
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2                                              
        2 2 8 2 2  8 2 2 8 2 2 8  2 2 8 2 2         
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2 
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2 
        2 2 8 2 2  8 2 2 8 2 2 8  2 2 8 2 2 
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2
        2 2 2 8 2  2 2 2 2 2 2 2  2 8 2 2 2
        2 2 2 2 2  8 2 2 8 2 2 8  2 2 2 2 2 
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2
        2 2 2 2 2  2 2 2 2 2 2 2  2 2 2 2 2   u=5  imp:n,p=1  $ 264-pin assembly      
c            
c
c
c
c                                                                               
29   5  -0.001293    -29                   u=9  imp:n,p=1  $ Empty $ Cf in air
30   5  -0.001293     29                   u=9  imp:n,p=1  $ Empty $ Cf in air
c
c
c
c
31    0    -28    fill=5  *trcl=(0.000 0.500 0.000)    imp:n,p=1  $ assembly  2-cm from source slab PE
c 31    0    -28    fill=9  *trcl=(0.000 0.000 0.000)    imp:n,p=1  $ Cf air
c
c   END Fuel Assembly Definition
c
c Cavity
100 5 -0.001293 (-422 #31 #190 #290 #390 #410)
                :(-424 408 -403 -429 430 #31 #190 #290 #390 #410)
                :(-424 409 403 -429 430 #31 #190 #290 #390 #410)   
                    imp:n,p=1
c
c ******************************************************************************
c #1 Cell 110
110 1 -0.965   -110                       u=101   imp:n,p=1   $ Org. Scint.
111 3 -2.23     -114:-115                  u=101   imp:n,p=1   $ Pyrex glass
112 0           -111 114                   u=101   imp:n,p=1   $ Void
113 2 -2.7      -116 115                   u=101   imp:n,p=1   $ Al
114 2 -2.7      -113 114 116               u=101   imp:n,p=1   $ Al
115 2 -2.7      -117                       u=101   imp:n,p=1   $ Al
116 2 -2.7      -112 110 111               u=101   imp:n,p=1   $ Al
117 4 -0.956    -121 123                   u=101   imp:n,p=1   $ PE
118 4 -0.956    -122 123                   u=101   imp:n,p=1   $ PE
119 5 -0.001293 #110 #111 #112 #113 
                #114 #115 #116 #117 #118   u=101   imp:n,p=1   $ Surrounding Air
c #2 Cell 120
120 1 -0.965   -110                       u=102   imp:n,p=1   $ Org. Scint.    
121 3 -2.23     -114:-115                  u=102   imp:n,p=1   $ Pyrex glass    
122 0           -111 114                   u=102   imp:n,p=1   $ Void           
123 2 -2.7      -116 115                   u=102   imp:n,p=1   $ Al             
124 2 -2.7      -113 114 116               u=102   imp:n,p=1   $ Al             
125 2 -2.7      -117                       u=102   imp:n,p=1   $ Al             
126 2 -2.7      -112 110 111               u=102   imp:n,p=1   $ Al             
127 4 -0.956    -121 123                   u=102   imp:n,p=1   $ PE             
128 4 -0.956    -122 123                   u=102   imp:n,p=1   $ PE             
129 5 -0.001293 #120 #121 #122 #123                                             
                #124 #125 #126 #127 #128   u=102   imp:n,p=1   $ Surrounding Air
c #3 Cell 130
130 1 -0.965   -110                       u=103   imp:n,p=1   $ Org. Scint.    
131 3 -2.23     -114:-115                  u=103   imp:n,p=1   $ Pyrex glass    
132 0           -111 114                   u=103   imp:n,p=1   $ Void           
133 2 -2.7      -116 115                   u=103   imp:n,p=1   $ Al             
134 2 -2.7      -113 114 116               u=103   imp:n,p=1   $ Al             
135 2 -2.7      -117                       u=103   imp:n,p=1   $ Al             
136 2 -2.7      -112 110 111               u=103   imp:n,p=1   $ Al             
137 4 -0.956    -121 123                   u=103   imp:n,p=1   $ PE             
138 4 -0.956    -122 123                   u=103   imp:n,p=1   $ PE             
139 5 -0.001293 #130 #131 #132 #133                                             
                #134 #135 #136 #137 #138   u=103   imp:n,p=1   $ Surrounding Air
c #4 Cell 140
140 1 -0.965   -110                       u=104   imp:n,p=1   $ Org. Scint.    
141 3 -2.23     -114:-115                  u=104   imp:n,p=1   $ Pyrex glass    
142 0           -111 114                   u=104   imp:n,p=1   $ Void           
143 2 -2.7      -116 115                   u=104   imp:n,p=1   $ Al             
144 2 -2.7      -113 114 116               u=104   imp:n,p=1   $ Al             
145 2 -2.7      -117                       u=104   imp:n,p=1   $ Al             
146 2 -2.7      -112 110 111               u=104   imp:n,p=1   $ Al             
147 4 -0.956    -121 123                   u=104   imp:n,p=1   $ PE             
148 4 -0.956    -122 123                   u=104   imp:n,p=1   $ PE             
149 5 -0.001293 #140 #141 #142 #143                                             
                #144 #145 #146 #147 #148   u=104   imp:n,p=1   $ Surrounding Air
c
c Left Panel
151 0  -100  fill=101 trcl=1     u=11    imp:n,p=1 $ Cell #1   $ Cell 110
152 0  -100  fill=102 trcl=2     u=11    imp:n,p=1 $ Cell #2   $ Cell 120
153 0  -100  fill=103 trcl=3     u=11    imp:n,p=1 $ Cell #3   $ Cell 130
154 0  -100  fill=104 trcl=4     u=11    imp:n,p=1 $ Cell #4   $ Cell 140
155 4 -0.956 -155 156 157 158 159 160 161 162 163
             #151 #152 #153 #154           u=11    imp:n,p=1 $ PE
160 5 -0.001293 #151 #152 #153 #154
                #155 #165 #166  
                #170                       u=11    imp:n,p=1 $ air
165 10 -8.65 -165                          u=11    imp:n,p=1 $ Cd
166 9 -11.34 -166                          u=11    imp:n,p=1 $ Lead
c
170 2 -2.7   -170 171                      u=11    imp:n,p=1 $ Al case
c
190 0  -190 fill=11   trcl=11                      imp:n,p=1 $ left-hand panel
c
c #5 Cell 210
210 1 -0.965   -110                       u=105   imp:n,p=1   $ Org. Scint.     
211 3 -2.23     -114:-115                  u=105   imp:n,p=1   $ Pyrex glass    
212 0           -111 114                   u=105   imp:n,p=1   $ Void           
213 2 -2.7      -116 115                   u=105   imp:n,p=1   $ Al             
214 2 -2.7      -113 114 116               u=105   imp:n,p=1   $ Al             
215 2 -2.7      -117                       u=105   imp:n,p=1   $ Al             
216 2 -2.7      -112 110 111               u=105   imp:n,p=1   $ Al             
217 4 -0.956    -121 123                   u=105   imp:n,p=1   $ PE             
218 4 -0.956    -122 123                   u=105   imp:n,p=1   $ PE             
219 5 -0.001293 #210 #211 #212 #213                                             
                #214 #215 #216 #217 #218   u=105   imp:n,p=1   $ Surrounding Air
c #6 Cell 220
220 1 -0.965   -110                       u=106   imp:n,p=1   $ Org. Scint.    
221 3 -2.23     -114:-115                  u=106   imp:n,p=1   $ Pyrex glass    
222 0           -111 114                   u=106   imp:n,p=1   $ Void           
223 2 -2.7      -116 115                   u=106   imp:n,p=1   $ Al             
224 2 -2.7      -113 114 116               u=106   imp:n,p=1   $ Al             
225 2 -2.7      -117                       u=106   imp:n,p=1   $ Al             
226 2 -2.7      -112 110 111               u=106   imp:n,p=1   $ Al             
227 4 -0.956    -121 123                   u=106   imp:n,p=1   $ PE             
228 4 -0.956    -122 123                   u=106   imp:n,p=1   $ PE             
229 5 -0.001293 #220 #221 #222 #223                                             
                #224 #225 #226 #227 #228   u=106   imp:n,p=1   $ Surrounding Air
c #7 Cell 230
230 1 -0.965   -110                       u=107   imp:n,p=1   $ Org. Scint.    
231 3 -2.23     -114:-115                  u=107   imp:n,p=1   $ Pyrex glass    
232 0           -111 114                   u=107   imp:n,p=1   $ Void           
233 2 -2.7      -116 115                   u=107   imp:n,p=1   $ Al             
234 2 -2.7      -113 114 116               u=107   imp:n,p=1   $ Al             
235 2 -2.7      -117                       u=107   imp:n,p=1   $ Al             
236 2 -2.7      -112 110 111               u=107   imp:n,p=1   $ Al             
237 4 -0.956    -121 123                   u=107   imp:n,p=1   $ PE             
238 4 -0.956    -122 123                   u=107   imp:n,p=1   $ PE             
239 5 -0.001293 #230 #231 #232 #233                                             
                #234 #235 #236 #237 #238   u=107   imp:n,p=1   $ Surrounding Air
c #8 Cell 240
240 1 -0.965   -110                       u=108   imp:n,p=1   $ Org. Scint.    
241 3 -2.23     -114:-115                  u=108   imp:n,p=1   $ Pyrex glass    
242 0           -111 114                   u=108   imp:n,p=1   $ Void           
243 2 -2.7      -116 115                   u=108   imp:n,p=1   $ Al             
244 2 -2.7      -113 114 116               u=108   imp:n,p=1   $ Al             
245 2 -2.7      -117                       u=108   imp:n,p=1   $ Al             
246 2 -2.7      -112 110 111               u=108   imp:n,p=1   $ Al             
247 4 -0.956    -121 123                   u=108   imp:n,p=1   $ PE             
248 4 -0.956    -122 123                   u=108   imp:n,p=1   $ PE             
249 5 -0.001293 #240 #241 #242 #243                                             
                #244 #245 #246 #247 #248   u=108   imp:n,p=1   $ Surrounding Air
c
c Right Panel
251 0  -100  fill=105 trcl=5     u=12    imp:n,p=1 $ Cell #5   $ Cell 210
252 0  -100  fill=106 trcl=6     u=12    imp:n,p=1 $ Cell #6   $ Cell 220
253 0  -100  fill=107 trcl=7     u=12    imp:n,p=1 $ Cell #7   $ Cell 230
254 0  -100  fill=108 trcl=8     u=12    imp:n,p=1 $ Cell #8   $ Cell 240
255 4 -0.956 -155 156 157 158 159 160 161 162 163
             #251 #252 #253 #254           u=12    imp:n,p=1 $ PE
260 5 -0.001293 #251 #252 #253 #254
                #255 #265 #266  
                #270                       u=12    imp:n,p=1 $ air
265 10 -8.65 -165                          u=12    imp:n,p=1 $ Cd
266 9 -11.34 -166                          u=12    imp:n,p=1 $ Lead
c
270 2 -2.7   -170 171                      u=12    imp:n,p=1 $ Al case
c
c
290 0  -190 fill=12   trcl=12                      imp:n,p=1 $ right-hand panel
c
c #9 Cell 310
310 1 -0.965   -110                       u=109   imp:n,p=1   $ Org. Scint.     
311 3 -2.23     -114:-115                  u=109   imp:n,p=1   $ Pyrex glass    
312 0           -111 114                   u=109   imp:n,p=1   $ Void           
313 2 -2.7      -116 115                   u=109   imp:n,p=1   $ Al             
314 2 -2.7      -113 114 116               u=109   imp:n,p=1   $ Al             
315 2 -2.7      -117                       u=109   imp:n,p=1   $ Al             
316 2 -2.7      -112 110 111               u=109   imp:n,p=1   $ Al             
317 4 -0.956    -121 123                   u=109   imp:n,p=1   $ PE             
318 4 -0.956    -122 123                   u=109   imp:n,p=1   $ PE             
319 5 -0.001293 #310 #311 #312 #313                                             
                #314 #315 #316 #317 #318   u=109   imp:n,p=1   $ Surrounding Air
c #10 Cell 320
320 1 -0.965   -110                       u=110   imp:n,p=1   $ Org. Scint.    
321 3 -2.23     -114:-115                  u=110   imp:n,p=1   $ Pyrex glass    
322 0           -111 114                   u=110   imp:n,p=1   $ Void           
323 2 -2.7      -116 115                   u=110   imp:n,p=1   $ Al             
324 2 -2.7      -113 114 116               u=110   imp:n,p=1   $ Al             
325 2 -2.7      -117                       u=110   imp:n,p=1   $ Al             
326 2 -2.7      -112 110 111               u=110   imp:n,p=1   $ Al             
327 4 -0.956    -121 123                   u=110   imp:n,p=1   $ PE             
328 4 -0.956    -122 123                   u=110   imp:n,p=1   $ PE             
329 5 -0.001293 #320 #321 #322 #323                                             
                #324 #325 #326 #327 #328   u=110   imp:n,p=1   $ Surrounding Air
c #11 Cell 330
330 1 -0.965   -110                       u=111   imp:n,p=1   $ Org. Scint.    
331 3 -2.23     -114:-115                  u=111   imp:n,p=1   $ Pyrex glass    
332 0           -111 114                   u=111   imp:n,p=1   $ Void           
333 2 -2.7      -116 115                   u=111   imp:n,p=1   $ Al             
334 2 -2.7      -113 114 116               u=111   imp:n,p=1   $ Al             
335 2 -2.7      -117                       u=111   imp:n,p=1   $ Al             
336 2 -2.7      -112 110 111               u=111   imp:n,p=1   $ Al             
337 4 -0.956    -121 123                   u=111   imp:n,p=1   $ PE             
338 4 -0.956    -122 123                   u=111   imp:n,p=1   $ PE             
339 5 -0.001293 #330 #331 #332 #333                                             
                #334 #335 #336 #337 #338   u=111   imp:n,p=1   $ Surrounding Air
c #12 Cell 340
340 1 -0.965   -110                       u=112   imp:n,p=1   $ Org. Scint.    
341 3 -2.23     -114:-115                  u=112   imp:n,p=1   $ Pyrex glass    
342 0           -111 114                   u=112   imp:n,p=1   $ Void           
343 2 -2.7      -116 115                   u=112   imp:n,p=1   $ Al             
344 2 -2.7      -113 114 116               u=112   imp:n,p=1   $ Al             
345 2 -2.7      -117                       u=112   imp:n,p=1   $ Al             
346 2 -2.7      -112 110 111               u=112   imp:n,p=1   $ Al             
347 4 -0.956    -121 123                   u=112   imp:n,p=1   $ PE             
348 4 -0.956    -122 123                   u=112   imp:n,p=1   $ PE             
349 5 -0.001293 #340 #341 #342 #343                                             
                #344 #345 #346 #347 #348   u=112   imp:n,p=1   $ Surrounding Air
c
c Rear Panel
351 0  -100  fill=109 trcl=5     u=13    imp:n,p=1 $ Cell #9   $ Cell 310
352 0  -100  fill=110 trcl=6     u=13    imp:n,p=1 $ Cell #10  $ Cell 320
353 0  -100  fill=111 trcl=7     u=13    imp:n,p=1 $ Cell #11  $ Cell 330
354 0  -100  fill=112 trcl=8     u=13    imp:n,p=1 $ Cell #12  $ Cell 340
355 4 -0.956 -155 156 157 158 159 160 161 162 163
             #351 #352 #353 #354           u=13    imp:n,p=1 $ PE
360 5 -0.001293 #351 #352 #353 #354
                #355 #365 #366  
                #370 #371 #372             u=13    imp:n,p=1 $ air
365 10 -8.65 -164                          u=13    imp:n,p=1 $ Cd
366 9 -11.34 -167                          u=13    imp:n,p=1 $ Lead
c
370 2 -2.7   -180 181                      u=13    imp:n,p=1 $ Al case
c
371 4 -0.956 -195 164 167                  u=13    imp:n,p=1 $ PE left  corner
372 4 -0.956 -196 164 167                  u=13    imp:n,p=1 $ PE right corner
c
390 0  -191 fill=13   trcl=13                      imp:n,p=1 $ rear panel
c
c Source Slab - BOTTOM
400 4 -0.956 (-400 -401 -403 #405):(-400 -402 403 #406)      
                                           u=113   imp:n,p=1 $ PE
401 10 -8.65 (-404 -405):(-404 -406):
             (-405 401 -403 404 -411 415 -416)
             :(-406 402 403 404 -411 415 -416)
                                           u=113   imp:n,p=1 $ Cd 
c 402 2 -2.7   (-407 410 -408 -403 #405):(-407 410 -409 403 #406)
c            :(-408 405 -403 -412):(-409 406 403 -412)
c                                           u=113   imp:n,p=1 $ Al
c
 405 0 -420  fill=500  trcl=21              u=113   imp:n,p=1 $ $ bottom-left AmLi
 406 0 -420  fill=600  trcl=22              u=113   imp:n,p=1 $ $ bottom-right AmLi
c 405 0 -420  fill=9  trcl=21              u=113   imp:n,p=1 $ $ bottom-left AmLi - air
c 406 0 -420  fill=9  trcl=22              u=113   imp:n,p=1 $ $ bottom-right AmLi - air
c                                                                                                    
409 5 -0.001293  #400 #401  #405 #406  u=113   imp:n,p=1 $ Air
c
410 0  (-440 -441 -403):(-440 -442 403) 
                   fill=113  trcl=24               imp:n,p=1 $ bottom Source Slab
c
c                   
c
900   6 -2.35     -900                        imp:n,p=1      $ concrete floor  
c
1000  5 -0.001293 -1000 #190 #290 #390 
              #410 #100 #31 #900              imp:n,p=1 
c              
c ******************************************************************************
c AmLi source Gammatron AN-HP Type-I Geometry source design
500 18 -0.75     -510              imp:n,p=1 U=500 $ N-530 source active volume
501 7  -8.00     -500  510         imp:n,p=1 U=500 $ inner capsule cap extending to source top
502 7  -8.00      500 -501         imp:n,p=1 U=500 $ inner source capsule
503 5  -0.001293  501 -502         imp:n,p=1 U=500 $ air gap between capsules
504 7  -8.00      502 -503         imp:n,p=1 U=500 $ outer source capsule
505 5  -0.001293  503 -504 511     imp:n,p=1 U=500 $ air gap between capsule & pig
506 16 -17.0      504 -505 507 508 imp:n,p=1 U=500 $ W pig
507 5  -0.001293  505 #513         imp:n,p=1 U=500 $ air around pig
508 5  -0.001293 -507              imp:n,p=1 U=500 $ 10-32 threaded hole in bottom of pig
509 5  -0.001293 -508              imp:n,p=1 U=500 $ 10-32 threaded hole in top of pig
510 5  -0.001293 -509              imp:n,p=1 U=500 $ 10-32 threaded hole in top of SUS
512 7  -8.00     -511  509         imp:n,p=1 U=500 $ BT part of outer can assembly
513 4  -0.956    -512              imp:n,p=1 U=500 $ PE holder
c
c ******************************************************************************  
c ******************************************************************************
c  AmLi source    Gammatron 2724-BT Type-II Geometry source design
600     18 -0.75     -610               imp:n,p=1 U=600  $ MRC-110 source active volume
601     5 -0.001293  -600  610          imp:n,p=1 U=600  $ air above source
602     7 -8.00       600 -601          imp:n,p=1 U=600  $ inner source capsule
603     5 -0.001293   601 -602          imp:n,p=1 U=600  $ air gap between capsules
604     7 -8.00       602 -603          imp:n,p=1 U=600  $ outer source capsule
605     5 -0.001293   603 -604 611      imp:n,p=1 U=600  $ air gap between capsule & pig
606     16 -17.0      604 -605 607 608  imp:n,p=1 U=600  $ W pig
607     5 -0.001293   605 #613          imp:n,p=1 U=600  $ air around pig
608     5 -0.001293  -607               imp:n,p=1 U=600  $ 10-32 threaded hole in bottom of pig  
609     5 -0.001293  -608               imp:n,p=1 U=600  $ 10-32 threaded hole in top of pig     
610     5 -0.001293  -609               imp:n,p=1 U=600  $ 10-32 threaded hole in top of SUS
612     7 -8.00      -611 609           imp:n,p=1 U=600  $ BT part of outer can assembly
613     4 -0.956     -612               imp:n,p=1 U=600  $ PE holder
c 
c ******************************************************************************
c                          
10000 0  1000                      imp:n,p=0                
c                
c ******************************************************************************

c ******************************************************************************
c Surfaces
c assembly      Vx  Vy  Vz  Hx  Hy  Hz  R                                       
20    rcc  0 0 -150 0 0 300 0.41275     $ pellets
21    rcc  0 0 -150 0 0 300 0.418      $ clad ID
22    rcc  0 0 -150 0 0 300 0.475       $ clad OD
23    rcc  0 0 -150 0 0 300 0.3       $ Gd rod ID
24    rcc  0 0 -150 0 0 300 0.51      $ Gd rod OD
25    rcc  0 0 -150 0 0 300 0.54      $ Guide tube ID
26    rcc  0 0 -150 0 0 300 0.59      $ Guide tube OD
c
27    rpp  -0.639     0.639    -0.639     0.639     -150 150        $ fuel lattice
28    rpp  -10.8630 10.8630 -10.8630 10.8630 -150 150        $ assembly overall
29    rpp  -11      11      -11      11      -150 150        $ Box for Cf-air  
c
c
110 rpp -4.7 4.7   -4.7 4.7   0.8  10.2  
111 rpp -4.7 4.7   -4.7 4.7   10.2 11.1
112 rpp -5   5     -5   5     0.5  11.1
113 rpp -5   5     -5   5     11.1 12.4
c
114 rcc  0   0  10.2      0  0 1.717  3.4
115 rcc  0   0  11.917    0  0 0.635  3.8
116 rcc  0   0  11.917    0  0 6.483  4.16
117 rcc  0   0  18.4      0  0 15.7   2.94
118 rpp -5   5     -5   5     12.4 34.1
119 rcc  0   0  12.4      0  0 6      4.16
c
c 100 rpp -5   5     -5   5     0.5  34.1
100 rpp -4.9999 4.9999  -4.9999 4.9999 0.49999 34.09999
101 rpp -5   5     -5   5     0.5  12.4
120 rcc  0   0  12.4      0  0 21.7      4.16
c
121 rpp -5   5  0   5        13.25  14.25
122 rpp -5   5  -5  0        13.25  14.25
123 rpp -5   5  -4.16  4.16  13.25  14.25
c
125 rpp -5.0001 5.0001  -5.0001 5.0001 0.49999 12.40001
126 rcc  0   0  12.3999   0 0 6.0002  4.16001
127 rcc  0   0  18.3999   0 0 15.7002 2.94001 
c
155 rpp -23.4 -13.4  -11.65 11.65  -14.25  14.25
156 rpp -23.4 -13.4   0.5   10.5    0.5    13.25
157 rpp -23.4 -13.4  -10.5  -0.5    0.5    13.25
158 rpp -23.4 -13.4   0.5   10.5   -13.25 -0.5
159 rpp -23.4 -13.4  -10.5  -0.5   -13.25 -0.5
160 rpp -23.4 -13.4   1.34   9.66   13.25  14.25 
161 rpp -23.4 -13.4  -9.66  -1.34   13.25  14.25
162 rpp -23.4 -13.4   1.34   9.66  -14.25 -13.25
163 rpp -23.4 -13.4  -9.66  -1.34  -14.25 -13.25
c
164 rpp -13.4 -13.3  -12.85 12.85  -14.25  14.25   $ Cd in rear panel
165 rpp -13.4 -13.3  -11.65 11.65  -14.25  14.25
166 rpp -13.3 -12.3  -11.65 11.65  -14.25  14.25
167 rpp -13.3 -12.3  -12.85 12.85  -14.25  14.25   $ lead in rear panel
168 rpp -12.2 -12    -11.65 11.65  -14.25  14.25
169 rpp -13.4 -12    -11.65 11.65  -14.25  14.25
c
170 rpp -23.6 -12    -11.85 11.85  -41  41     $ Al case
171 rpp -23.4 -12.2  -11.65 11.65  -40.8 40.8
c
180 rpp -23.6 -12    -23.00 23.00  -41  41     $ Al case for Rear Panel
181 rpp -23.4 -12.2  -22.80 22.80  -40.8 40.8
c
190 rpp -23.5999 -11.9999 -11.8499 11.8499 -40.9999 40.9999  $ Panel
c
191 rpp -23.5999 -11.9999 -22.9999 22.9999 -40.9999 40.9999  $ Rear Panel
c
195 rpp -23.4 -12.3  -22.8 -11.65  -14.25  14.25     $ PE left corner
196 rpp -23.4 -12.3  11.65  22.8   -14.25  14.25     $ PE right corner
c
c
c Source Slab
400 rpp -22.8 22.8 -22.3 -12.3  -14.25   14.25       $ PE
401 14 py  -12.3
402 15 py  -12.3
403 px 0
c
404 rpp -11.4 11.4 -12.3 -12.2  -14.25   14.25       $ Cd
405 14 py  -12.2
406 15 py  -12.2
c
407 rpp -23.0 23.0 -22.2 -12.2    -14.55  14.55      $ Al
408 14 py  -12
409 15 py  -12
c
410 rpp -22.8 22.8 -22.3 -12.2  -14.25  14.25      $ Air
411 py -12.3
412 py -12.2
c
415 pz -14.25
416 pz  14.25
c
420 rcc 0 0 0  0 0 41.55   1.905                     $ AmLi hole
421 rcc 0 0 0  0 0 41.55   0.57                      $ Cm   hole
c
c Cavity
422 rpp -12 12 -12 12  -151 151
423 py 12
424 py -12
425 px 12
c 426 px -12
427 16 py 12
428 17 py 12
429 pz 151
430 pz -151
c
440 rpp -22.99999 22.99999 -22.19999 -12.19999   -14.24999  14.24999      $ Al
441 14 py  -12.2001
442 15 py  -12.2001
c
c *****************************************************************************
c AmLi source Gammatron Type-I Geometry source design
500 20 rcc 0 0 1.3208 0 0 1.4732 1.0312 $ inside inner SUS can
501 20 rcc 0 0 1.0668 0 0 2.2352 1.1455 $ outside inner SUS can
502 20 rcc 0 0 1.0668 0 0 2.2860 1.1519 $ inside outer SUS can
503 20 rcc 0 0 0.7620 0 0 2.8956 1.2700 $ outside outer SUS can
504 20 rcc 0 0 0.7620 0 0 3.6830 1.3210 $ W pig inside
505 20 rcc 0 0 0.0000 0 0 5.7150 1.5875 $ W pig outside
507 20 rcc 0 0 0.0000 0 0 0.6350 0.1984 $ 10-32 threaded hole in bottom of pig
508 20 rcc 0 0 5.0800 0 0 0.6350 0.1984 $ 10-32 threaded hole in top of pig
509 20 rcc 0 0 3.6576 0 0 0.6350 0.1984 $ 10-32 threaded hole in BT part of outer can
510 20 rcc 0 0 1.3209 0 0 1.1500 1.0312 $ AmLi source pellet (N-530)
511 20 rcc 0 0 3.6576 0 0 0.6350 1.2700 $ BT part of outer can
512 20 rcc 0 0 5.7150 0 0 20     1.900  $ PE holder
c
c *****************************************************************************
c
c *****************************************************************************
c  AmLi source    Gammatron 2724-BT Type-II Geometry source design
600  31 rcc  0 0 1.3209  0 0 1.2000   1.0312    $ inside inner SUS can 1.7272 is MRC lid thickness
601  31 rcc  0 0 1.0668  0 0 2.2860   1.1455    $ outside inner SUS can                           
602  30 rcc  0 0 1.0668  0 0 2.2860   1.1519    $ inside outer SUS can                            
603  30 rcc  0 0 0.7620  0 0 2.8448   1.2700    $ outside outer SUS can                           
604  30 rcc  0 0 0.7620  0 0 3.6830   1.3210    $ W pig inside                                    
605  30 rcc  0 0 0.0000  0 0 5.7150   1.5875    $ W pig outside                                   
607  30 rcc  0 0 0.0000  0 0 0.6350   0.1984    $ 10-32 threaded hole in bottom of pig            
608  30 rcc  0 0 5.0800  0 0 0.6350   0.1984    $ 10-32 threaded hole in top of pig               
609  30 rcc  0 0 3.6068  0 0 0.6350   0.1984    $ 10-32 threaded hole in BT part of outer can      
610  31 rcc  0 0 1.3209  0 0 1.1500   1.0312    $ AmLi source pellet (N-530)                      
611  30 rcc  0 0 3.6068  0 0 0.6350   1.2700    $ BT part of outer can 
612  30 rcc  0 0 5.7150  0 0 20       1.900     $ PE holder                           
c
c *****************************************************************************
c
c 1000 S 0 0 0 100 
900  rpp -200 200 -200 200 -257.5  -227.5
1000 rpp -200 200 -200 200 -257.5  200 
c ******************************************************************************

c ******************************************************************************
c Material Card
c
c TR for Panel on lefthand
tr1 -18.4  5.5 0
tr2 -18.4 -5.5 0
tr3 -18.4  5.5 0  -1 0 0  0 1 0  0 0 -1
tr4 -18.4 -5.5 0  -1 0 0  0 1 0  0 0 -1  
c TR for Panel on righthand
tr5 -18.4  5.5 0                        
tr6 -18.4 -5.5 0                        
tr7 -18.4  5.5 0  -1 0 0  0  1 0  0 0 -1 
tr8 -18.4 -5.5 0  -1 0 0  0  1 0  0 0 -1 
tr11   0.6  -0.15  0 
tr12  -0.6  -0.15  0  -1 0 0  0 -1 0  0 0  1
c tr11   0.5  0  0 
c tr12  -0.5  0  0  -1 0 0  0 -1 0  0 0  1
tr13   0    0  0  0 -1 0  1 0 0 0 0 1
c
*tr14 0 0 0  30  120 90  -60 30  90  90  90  0 
*tr15 0 0 0  -30 60  90  -120  -30 90  90  90  0
c *tr14 0 -2.2 0  30  120 90  -60 30  90  90  90  0 
c *tr15 0 -2.2 0  -30 60  90  -120  -30 90  90  90  0
c
*tr16 0 2.2 0  30  120 90  -60 30  90  90  90  0 
*tr17 0 2.2 0  -30 60  90  -120  -30 90  90  90  0
c
tr20 0 0 0   $ move AmLi Source
c
c tr21 -8 -14.5 -2    $ bottom-left AmLi
c tr22  8 -14.5 -2    $ bottom-right AmLi
tr21 -3.5 -14.5 -2    $ bottom-left AmLi
tr22  3.5 -14.5 -2    $ bottom-right AmLi
c
tr24 0  0.2  0                        $ Bottom Source Slab
tr25 0  -0.2  0  -1 0 0  0 -1 0  0 0 1  $ Top Source Slab
c
tr30 0 0 0     $ move AmLi Source
tr31 0 0 4.4196     -1 0 0  0 -1 0  0 0 -1   $ flip AmLi Source inner can
c
m1   nlib=80c  plib=04p
       1001      0.548          
       6000      0.452        
mt1   poly.10t
c
m2   NLIB=80c PLIB=04P 
     13027 1            
mt2  al27.12t
c
m3   NLIB=80c PLIB=04P  $ pyrex glass (data taken from PNNL materials list)
     5011  -0.040064        
     8016.60c  -0.539562   
     11023.60c -0.028191        
     13027.60c -0.011644        
     14000.60c -0.377220        
     19000.62c -0.003321       
c
m4   NLIB=80c PLIB=04P  $ HDPE
     6000 1 $ 0.666667       
     1001  2 $ 0.333333      
mt4   poly.10t
c
c
m6  NLIB=80c PLIB=04P  $ concrete, ordinary (NBS 03), density 2.35 kg/cm3
     1001 -0.008485
     6000.60c -0.050064
     8016.60c -0.473483
     12000.62c -0.024183
     13027.60c -0.036063 
     14000.60c -0.145100
     16000.62c -0.002970
     19000.62c -0.001697
     20000.60c -0.246924
     26000.55c -0.011031
c
m5   NLIB=80c PLIB=04P $ Air (dry, near sea level), dencity 0.001205 g/cm3
     6000 -0.000124
     7014 -0.755268
     8016 -0.231781
     18000.59c -0.012827
     98252 -1E-20           
c
m7   NLIB=80c PLIB=04P  $ SS304, from PNNL materials list (8 g/cc)
     6000 -0.000400
     14000 -0.005000
     15031 -0.000230
     16000 -0.000150
     24000.50c -0.190000
     25055 -0.010000
     26000.55c -0.701730
     28000.50c -0.092500 
c
m8   NLIB=80c PLIB=04P $ teflon
     6000 2
     9019 4
c
m9   NLIB=80c PLIB=04P
     82000 1
c
m10  NLIB=80c PLIB=04P
     48000 1
c
c
m14  NLIB=80c PLIB=04P $ Natural He3 filling
     2004 0.99999
     2003 1e-005
c
m15  NLIB=80c PLIB=04P $ Cladding (Zircaloy-2 from PNNL) (density= -6.56 g/cm3)
     8016 -0.001197
     24000 -0.000997
     26000 -0.000997
     28000 -0.000499
     40000 -0.982348
     50000 -0.013962
c     
c Material 16 -- Tungsten (90-6-4, machinable, non-magnetic) (density= -17.0 g/cm3)
m16   NLIB=80c PLIB=04P
      28058 1.0657E-01
      28060 4.0743E-02
      28061 1.7640E-03
      28062 5.6041E-03
      28064 1.4205E-03
      29063 6.6512E-02
      29065 2.9645E-02
c 74180 8.9729E-04
      74182 1.9666E-01
      74183 1.0678E-01
      74184 2.2956E-01
      74186 2.1385E-01
c
c
c Material 18 AmO2*183Li2O source pellet ( -0.75 g/cc) (Monsanto & Gammatron C-series)
m18   NLIB=80c PLIB=04P
      95241 1
      3006 14.8
      3007 168.3
      8016 93.6
c
c Material 19 AmO2*117Li2O source pellet ( -0.75 g/cc) (Gammatron N-Series)
m19   NLIB=80C PLIB=04P
      95241 1
      3006 9.74
      3007 107.4
      8016 60.4
c
c ---- Fuel Assembly ----      
c
c 1.16% enrichment UO2
m20      92235.80c -0.01023  92238.80c -0.87127  8016.80c -0.11850
mt20  o2/u.10t u/o2.10t 
c        
c
Print
Mode N P 
c ! The following two PHYS cards and CUT:P are essential for analog MC
PHYS:N 20 20 0   
PHYS:P 0 1 1
c The following CUT cards kill neutrons and photons having times 
c exceeding 10us after the originating source event
c CUT:N 1000      
CUT:P 2J 0
c SOURCE DEFINITION
sdef par=n cel=d4 pos=FCEL=d5 erg=d1 rad=d2 ext=d3 axs=0 0 1  tme=d6
si4 L 410:405:500  410:406:600 
sp4   4e4     6e4           $ Relative yields of AmLi sources
ds5 S 7            8
si7 L 0 0 1.3209                      $ Begin Z of AmLi pellet 
sp7 1       
si8 L 0 0 1.9487                      $ 4.4196 (tr31) -(1.3209 + 1.15) = 1.9487
sp8 1
c
si2 0 1.030 $ AmLi radius
sp2 -21 1
si3 0 1.15 $ AmLi Height
sp3 -21 0
c
SC1 SGTS-2 AmLi Spectrum, AmO2+190Li2O, Gammatron Fit, DHB, IAEA, 2014
#       SI1       SP1
        H         D
        0.0       0.0
        0.025     0.048
        0.05      0.065
        0.075     0.084
        0.1       0.1
        0.15      0.129
        0.2       0.178
        0.25      0.203
        0.3       0.212
        0.35      0.189
        0.4       0.155
        0.45      0.106
        0.5       0.09
        0.55      0.085
        0.6       0.08
        0.65      0.07
        0.7       0.06
        0.75      0.054
        0.8       0.05
        0.85      0.046 
        0.9       0.038
        0.95      0.031
        1.0       0.028
        1.05      0.022
        1.1       0.017
        1.15      0.012
        1.2       0.009
        1.25      0.005
        1.3       0.004 
        1.35      0.004
        1.4       0.004 
        1.45      0.003
        1.5       0.004
        1.75      0.025
        2.0       0.04
        2.25      0.03
        2.5       0.025
        3.0       0.01
        3.5       0.007
c
SI6  0 6E10
SP6  0 1
NPS  6E3  $ 6E7 
c OTHER CARDS
c
IPOL 0 1 2 1 2J 12 110 120 130 140 210 220 230 240 310 320 330 340
RPOL 1e-3 1e-3
files 21 DUMN1   $ 3J 22 DUMN2
DBCN
PRDMP 4J -1




