      program circle
      real r, area
      parameter (pi = 3.14159)
      integer i,n,s
      s = 0
      n = 20


!     This program reads a real number r and prints
!     the area of the circle with radius r.

      write (*, *) 'Give radius r:'
      read  (*, *) r
      area = pi * r * r
      if (area .lt. 40) then
        write (*, *) 'Area =', area
      else
        write (*,*) 'Incorrect answer =',r,pi
      endif

!     Do loop


      do 10 i = 1, n
        s = s + 1
        write (*, *) 'i =', i
        write (*, *) 's =', s
10    continue


      stop
      end
